using UnityEditor;
using UnityEngine;
using System.IO;
using LitJson;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using mmowar;
/// <summary>
/// 生成json配置文件
/// 1.创建资源文件夹
/// 2.得到选中文件夹
/// 3.获取选中文件夹下的Prefab
/// 4.构建选中文件夹下的路径
/// 
/// </summary>
public class GeneraterProFile  {
    /// <summary>
    /// 配置文件目录
    /// </summary>

    public const string RESOURCES = "Resources";
    public const string PROFILE_PATH = "ProFile";
    public const string PathHua = "/";

    /// <summary>
    /// 生成perfabPath文件
    /// </summary>
    [MenuItem("MyMenu/GenerPerfabPathfile")]
    public static void GeneraterPrefabProFile()
    {
        CreatePrefabProfile(FileSuffix.PrefabSuff);
    }

    [MenuItem("MyMenu/GenerMap3Pathfile")]
    public static void GeneraterAudioclipProFile()
    {
        CreatePrefabProfile(FileSuffix.Map3);
    }

    /// <summary>
    /// 获取所有的资源文件列表
    /// </summary>
    [MenuItem("MyMenu/GenerfileList")]
    public static void ProFile()
    {
        CreatePrefabProfile(".json");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns> 返回选中Asset选中目录</returns>
    public static string getSelectPath()
    {
        //选择的文件
        Object file = Selection.activeObject;
        string selectpath = AssetDatabase.GetAssetPath(file);
        Debug.Log("选择的原始路径"+selectpath);
        return selectpath;
    }

    /// <summary>
    ///  创建prefab资源文件
    /// </summary>
   public static void CreatePrefabProfile(string suffix)
    {
        string selectpath = getSelectPath();       //获得选择路径
        string substr = selectpath.Substring(17); //截取至res
        string dirpath = Application.dataPath + PathMgr.PathHua + selectpath.Substring(selectpath.IndexOf(RESOURCES));
        DirectoryInfo di = new DirectoryInfo(dirpath); //获取文件夹信息
        string ProFileName = substr.Replace('/','_'); //将文件夹重命名
       // Debug.Log("资源文件名:" + ProFileName);
        if (ProFileName.Equals("ResFile"))
        {
            ProFileName = "ResFilelis";
        }

        BuildlerJsonFile(di, substr, ProFileName, suffix);

        //if (ProFileName == "ResFilelis")
        //{
        //    return;
        //}

        BuildlerEmunFile(di, ProFileName, suffix);

        //TestReadFile(ProFileName);
    }

    public static void BuildlerEmunFile(DirectoryInfo di, string filename, string suffix)
    {

        string enumPath = PathMgr.getAssetPath() + "/Script/u3d_scripts/Define";
        FileStream enumf = CreateFile(enumPath, filename, ".cs");
        string enumStr = FileListEnumstr(di, filename, suffix);

        StreamWriter sw2 = new StreamWriter(enumf, Encoding.UTF8);
        try
        {

            sw2.Write(enumStr);
            sw2.Flush();
        }
        catch (IOException e)
        {
            Debug.Log(e.ToString());
            Debug.Log("创建失败");
        }
        finally
        {
            enumf.Close();
            sw2.Close();
        }
        Debug.Log("创建成功");

    }

    //创建jsonfile
    public static void BuildlerJsonFile(DirectoryInfo di,string pingString, string filename, string suffix)
    {
        //Debug.Log("选择文件截取" + substr);
        string ProfilePath = PathMgr.GetTextFilePath();
        //Debug.Log("资源文件路径" + ProfilePath);
        ////创建资源文件
        if (!Directory.Exists(ProfilePath))
        {
            Debug.Log("资源文件不存在" + ProfilePath);
            Directory.CreateDirectory(ProfilePath);
        }

        FileStream fs = CreateFile(ProfilePath, filename);
        string jsonString = FileListToJsonStr(di, pingString + PathHua, suffix);
        StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
        try
        {
            sw.Write(jsonString);
            sw.Flush();

        }
        catch (IOException e)
        {
            Debug.Log(e.ToString());
            Debug.Log("创建失败");
        }
        finally
        {
            sw.Close();
            fs.Close();
        }
        Debug.Log("创建成功");

    }

    //向文件里面写json字符串
    public static string FileListToJsonStr(DirectoryInfo di,string Pinstr ,string suff = ".prefab")
    {
        JsonData root = new JsonData();
        int idx = 1;
        string str = "";
        if (di == null)
        {
            Debug.Log("创建失败");
            return str;
        }
        foreach (FileInfo item in di.GetFiles("*" + suff, SearchOption.AllDirectories))
        {
            string fullname = item.FullName.ToString();
            string subPrefabPath = fullname.Substring(0, fullname.IndexOf(suff));
            subPrefabPath = subPrefabPath.Substring(subPrefabPath.LastIndexOf("\\") + 1);
            if (subPrefabPath == "ResFilelis")
            {
                continue;
            }
            JsonData jd = new JsonData();
            jd["Type"] = idx++;
            jd["PathName"] = Pinstr + subPrefabPath;
            root.Add(jd);
        }
        return root.ToJson();
    }



    //创建枚举字符串
    public static string FileListEnumstr(DirectoryInfo di,string enumName, string suff = ".prefab")
    {

        string str = "";
        int idx = 0;
        StringBuilder st = new StringBuilder();

        st.Append("public enum   ").Append(enumName).Append(" : ushort").Append("\n{ \n");

        st.Append("\t None").Append("   =   ").Append(idx).Append(",\n");
        foreach (FileInfo item in di.GetFiles("*" + suff, SearchOption.AllDirectories))
        {
            string fullname = item.FullName.ToString();
            string subPrefabPath = fullname.Substring(0, fullname.IndexOf(suff));
            subPrefabPath = subPrefabPath.Substring(subPrefabPath.LastIndexOf("\\") + 1);
            if (subPrefabPath == "ResFilelis")
            {
                continue;
            }

            st.Append("\t").Append(subPrefabPath).Append("_EM").Append("    =   ").Append(++idx).Append(",\t\t  \n");
        }

        st.Append("}");

        str = st.ToString();
        return str;
    }

    public static void TestReadFile(string ProFileName)
    {
        string filePath = PathMgr.GetTextFilePath() + PathMgr.PathHua + ProFileName + ".json";
        StreamReader sr = new StreamReader(filePath);
        string  json =  sr.ReadToEnd();
        Debug.Log(json);

        JsonData jd =  JsonMapper.ToObject(json);

        foreach (JsonData item in jd)
        {
            Debug.Log(item["Type"] +"-"+ item["PathName"]);
        }
    }
    public static FileStream CreateFile(string  filepath,string fileName,string suffixName =".json")
    {

        string path = filepath + PathMgr.PathHua + fileName + suffixName;
        //创建文件
        FileStream myFS;
        if (File.Exists(path))
        {
            Debug.Log(path + "文件已经存在");
            myFS = File.OpenWrite(path);
            return myFS;
        }
        else Debug.Log(fileName);

        myFS = File.Create(path);

        return myFS;
        //创建文件夹
        //Directory.CreateDirectory(Application.dataPath + "/Files");

        //缓冲类BufferedStream读取文件

        //int c;
        //BufferedStream myBS = new BufferedStream(new FileStream(path, FileMode.Open));
        //while ((c = myBS.ReadByte()) != -1)
        //{
        //    s += ((int)c).ToString();
        //    print(((char)c).ToString());
        //}
        //print(s);

        /*
        FileStream myFS=new FileStream(path,FileMode.OpenOrCreate);
        myChar="My first file!".ToCharArray();
        Encoder myEncoder=Encoding.UTF8.GetEncoder();
        myEncoder.GetBytes(myChar,0,myChar.Length,myByte,0,true);//设置流的位置从0开始
        myFS.Write(myByte,0,myByte.Length);   //将字节数组写入文件
        */
    }
   

    /// <summary>
    /// 最后带下划线的文件路径
    /// </summary>
    /// <returns></returns>
    public static string GetProFilePathHasHua()
    {

        return Application.dataPath + PathHua + RESOURCES + PathHua + PROFILE_PATH + PathHua;
    }
}
