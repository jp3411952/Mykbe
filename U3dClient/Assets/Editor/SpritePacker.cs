using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace mmowar
{



public class SpritePacker  {

    [MenuItem("MyMenu/AtlasMaker")]
    static private void MakeAtlas()
    {

            //Object [] files =

            //foreach (var item in files)
            //{
            //    Debug.Log(item.name);
            //}
            string spriteDir = Application.dataPath + "/Resources/Prefab/Sprite/";
            DirectoryInfo rootDirInfo = new DirectoryInfo(Application.dataPath + "/UIAtlas");
            foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories())
            {
                
                
                string subFileName = dirInfo.Name.Substring(5);
                string realSpriteDir = spriteDir + subFileName;
                if (!Directory.Exists(realSpriteDir))
                {
                    Directory.CreateDirectory(realSpriteDir);
                }
                foreach (FileInfo pngFile in dirInfo.GetFiles("*.png", SearchOption.AllDirectories))
                {
                    string allPath = pngFile.FullName;

                    Debug.Log(allPath);
                    string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
                    Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
                    GameObject go = new GameObject(sprite.name);
                    go.AddComponent<SpriteRenderer>().sprite = sprite;
                    allPath = realSpriteDir + "/" + sprite.name + ".prefab";
                    string prefabPath = allPath.Substring(allPath.IndexOf("Assets"));
                    PrefabUtility.CreatePrefab(prefabPath, go);
                    GameObject.DestroyImmediate(go);
                }
            }
        }

   
    //[MenuItem("MyMenu/Build Assetbundle")]
    //static private void BuildAssetBundle()
    //{
    //    string dir = Application.dataPath + "/StreamingAssets";
    //    if (!Directory.Exists(dir))
    //    {
    //        Directory.CreateDirectory(dir);
    //    }
    //    DirectoryInfo rootDirInfo = new DirectoryInfo(Application.dataPath + "/Atlas");
    //    foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories())
    //    {
    //        List<Sprite> assets = new List<Sprite>();
    //        string path = dir + "/" + dirInfo.Name + ".assetbundle";
    //        foreach (FileInfo pngFile in dirInfo.GetFiles("*.png", SearchOption.AllDirectories))
    //        {
    //            string allPath = pngFile.FullName;
    //            string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
    //            assets.Add(AssetDatabase.LoadAssetAtPath<Sprite>(assetPath));
    //        }
    //        //if (BuildPipeline.BuildAssetBundle(null, assets.ToArray(), path, BuildAssetBundleOptions.UncompressedAssetBundle | BuildAssetBundleOptions.CollectDependencies, BuilderTools.GetBuildTarget()))
    //        {
    //        }
    //    }
    //}
 
}
}
