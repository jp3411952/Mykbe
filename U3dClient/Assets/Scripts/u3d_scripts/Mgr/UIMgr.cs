using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public  class UIMgr
{
    static UIMgr _instance;

    static UIMgr()
    {
        if (_instance == null)
            _instance = new UIMgr();
    }
    private UIMgr()
    {
          
    }
    public static UIMgr Instance
    {
        get
        {
            return _instance;
        }
    }


    /// <summary>
    /// 设置所有子物体的层级
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="layer"></param>
    public static void SetLayerOnAll(GameObject obj, int layer)
    {
        if (null == obj)
            return;
        foreach (Transform trans in obj.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layer;
        }

    }

    /// <summary>
    /// 递归设置
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="layer"></param>
    public static void SetLayerRecusively(GameObject obj, int layer)
    {
        if (null == obj)
            return;

        obj.layer = layer;
        foreach (Transform child in obj.transform)
            SetLayerRecusively(child.gameObject, layer);
    }

    public static T GetComponentInChildrenByName<T>(string gameObjectName, Transform parent) where T : Component
    {
        GameObject go = GetGameObjectInChildren(gameObjectName, parent);
        T comp = null;
        if (go != null)
        {
            comp = go.GetComponent<T>();
        }
        return comp;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">返回组件</typeparam>
    /// <param name="go"></param>
    /// <returns></returns>
    public T  GetOrAddComponent<T>(GameObject go) where T : Component
    {
        T t = go.GetComponent<T>();
        if (t == null)
        {
            t = go.AddComponent<T>();
        }
        return t;
    }
    /// <summary>
    /// 查看是否有某個組建
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <returns></returns>
    public bool HasComponent<T>(GameObject go) where T : Component
    {
        T t = go.GetComponent<T>();
        if (t == null)
            return false;

        return true;
    }
    /// <summary>
    /// Find a GameObject called gameobjectname in mine Transform or others
    /// </summary>
    /// <param name="gameObjectName"></param>
    /// <param name="t">，</param>
    /// <returns> </returns>
    public static GameObject GetGameObjectInChildren(string gameObjectName, Transform t)
    {
        if (t == null)
            throw new ArgumentNullException("t");

        foreach (Transform child in t)
        {
            if (child.name == gameObjectName)
            {
                return child.gameObject;
            }
            GameObject go = GetGameObjectInChildren(gameObjectName, child);

            if (go != null)
            {
                return go;
            }
        }
        return null;
    }
}
