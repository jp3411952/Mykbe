using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using mmowar;
using UnityEngine;

/// <summary>
/// 管理配置
/// </summary>
 public   class PropertyMgr :MonoBehaviour
{
    public static PropertyMgr _instance;


    private float delay = 0.1f;

    public readonly static  Dictionary<uint, object> avatarProperty =new Dictionary<uint, object>(); 

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    private void Start()
    {
        string path = PathMgr.PropertyFile + "AllPath";
        ResouceMgr._instanse.LoadAsyco(path, LoadAllPathFileCallBack);
    }


    /// <summary>
    /// 异步加载单个文件
    /// </summary>
    /// <param name="path"></param>
    /// <param name="sec"></param>
    /// <returns></returns>
    IEnumerator LoadOneFile (string path,Action<UnityEngine.Object> action)
    {
        yield return ResouceMgr._instanse.LoadAsyco(path, action);
        yield return null;
    }

    //解析单个配置文件
    public void LoadPropertyfileCallBack(UnityEngine.Object obj)
    {
        JsonData jd = TextToJson(obj);
        
        switch (obj.name)
        {
            case "AvatarProperty":
               // ParsProperty<object>(jd, avatarProperty);
                break;

        }
   
    }

    public void ParsProperty<T>(JsonData jd,Dictionary<uint,T> properdic) 
    {
        if (jd == null)
        {
            return;
        }
        //多个资源文件路径
        foreach (JsonData item in jd)
        {
            uint id = 0;
            if (!uint.TryParse(item["id"].ToString(), out id))
            {
                continue;
            }
            string json = item.ToString();
            T ap = JsonMapper.ToObject<T>(json);
            properdic[id] = ap;
        }
    }


    public void LoadAllPathFileCallBack(UnityEngine.Object obj)
    {
       
        JsonData jd = TextToJson(obj);
        if (jd == null)
        {
            return;
        }
        //只有一个资源文件
        if (jd.Count == 1)
        {
            string path = jd[0]["PathName"].ToString();
            CoroutineMgr._instance.m_UiCoroutine.StartCoroutine(LoadOneFile(path, LoadPropertyfileCallBack));
            return;
        }
        //多个资源文件路径
        foreach (JsonData item in jd)
        {
            string path = item["PathName"].ToString();
            StartCoroutine(LoadOneFile(path, LoadPropertyfileCallBack));
            //PathMgr._instanse.AddResFileName(i, path);
        }
    }


    public JsonData TextToJson(UnityEngine.Object obj)
    {
        JsonData jd = new JsonData();
        if (obj == null)
        {
           return jd;
        }
        TextAsset go = obj as TextAsset;
        jd = JsonMapper.ToObject(go.text);

        return jd;
    }

}
