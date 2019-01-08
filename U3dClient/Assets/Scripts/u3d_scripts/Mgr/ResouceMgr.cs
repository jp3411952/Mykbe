
using KBEngine;
using mmowar;
using System;
using System.Collections;
using System.IO;
using UnityEngine;

/// <summary>
/// 资源路径
/// </summary>
public struct ResData
{
   public int resType;  // 资源类型
   public int subKey;    // 在对应资源 列表中的key
   public string pathName;    //具体的资源路径
}


public class ResouceMgr : MonoBehaviour
{
  
    //异步加载资源
    public static ResouceMgr _instanse;

    private void Awake()
    {
        _instanse = this;
    }

    /// <summary>
    /// 携程加载
    /// </summary>
    /// <param name="rd">资源信息附加资源类型</param>
    /// <param name="CoroutineCallBack"></param>
    public void LoadResources(ResData rd,Action<ResData, UnityEngine.Object> CoroutineCallBack)
    {
        StartCoroutine(LoadSource(rd, CoroutineCallBack));
    }
    /// <summary>
    /// 携程加载资源
    /// </summary>
    /// <param name="tkey"></param>
    /// <param name="tpath"></param>
    /// <param name="CoroutineCallBack"></param>
    public void LoadResourcesKey(int tkey ,string tpath, Action<int, UnityEngine.Object> CoroutineCallBack)
    {
        StartCoroutine(LoadSource(tkey, tpath, CoroutineCallBack));
    }


    public IEnumerator LoadAsyco( string tpath, Action<UnityEngine.Object> CoroutineCallBack)
    {
        yield return StartCoroutine(LoadAsyncSource(tpath, CoroutineCallBack));
    }

    /// <summary>
    /// 协成异步加载资源
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    IEnumerator LoadSource(ResData rd, Action<ResData, UnityEngine.Object> CoroutineCallBack)
    {
       ResourceRequest m_resourceReq = Resources.LoadAsync(rd.pathName);

        yield return m_resourceReq;

        if (m_resourceReq == null)
        {
            yield return  null;
        }
      
        while (!m_resourceReq.isDone)
        {
            Dbg.ERROR_MSG(string.Format("资源 ={0}未完成", rd.pathName));
            yield return null;
        }

        if (m_resourceReq.asset == null)
        {
            Dbg.ERROR_MSG(string.Format("资源 ={0}不存在", rd.pathName));
            yield  break;
        }

        if (CoroutineCallBack != null)
        {
            //Dbg.ERROR_MSG(string.Format("资源 ={0}不存在", path));
            UnityEngine.Object go = Instantiate(m_resourceReq.asset) as UnityEngine.Object;

            if (go == null)
            {
                Dbg.ERROR_MSG(string.Format("资源未创建成功"));
                yield break;
            }
            CoroutineCallBack(rd, go);
            yield break;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="key">对应资源的key</param>
    /// <param name="path">资源相对坐标</param>
    /// <param name="CoroutineCallBack"></param>
    /// <returns></returns>
    IEnumerator LoadSource(int tkey, string tpath, Action<int, UnityEngine.Object> CoroutineCallBack)
    {
        ResourceRequest m_resourceReq = Resources.LoadAsync(tpath);

        yield return m_resourceReq;

        if (m_resourceReq == null)
        {
            yield return null;
        }

        while (!m_resourceReq.isDone)
        {
            Dbg.ERROR_MSG(string.Format("资源 ={0}未完成", tpath));
            yield return null;
        }

        if (m_resourceReq.asset == null)
        {
            Dbg.ERROR_MSG(string.Format("资源 ={0}不存在", tpath));
            yield break;
        }

        if (CoroutineCallBack != null)
        {
            //Dbg.ERROR_MSG(string.Format("资源 ={0}不存在", path));
            UnityEngine.Object go = Instantiate(m_resourceReq.asset) as UnityEngine.Object;

            if (go == null)
            {
                Dbg.ERROR_MSG(string.Format("资源未创建成功"));
                yield break;
            }
            CoroutineCallBack(tkey, go);
            yield break;
        }
    }

    IEnumerator LoadAsyncSource(string tpath,Action<UnityEngine.Object> CoroutineCallBack)
    {
        ResourceRequest m_resourceReq = Resources.LoadAsync(tpath);

        yield return m_resourceReq;

        if (m_resourceReq == null)
        {
            yield return null;
        }

        while (!m_resourceReq.isDone)
        {
            Dbg.ERROR_MSG(string.Format("资源 ={0}未完成", tpath));
            yield return null;
        }

        if (m_resourceReq.asset == null)
        {
            Dbg.ERROR_MSG(string.Format("资源 ={0}不存在", tpath));
            yield break;
        }

        if (CoroutineCallBack != null)
        {
            //Dbg.ERROR_MSG(string.Format("资源 ={0}不存在", path));
            UnityEngine.Object go = Instantiate(m_resourceReq.asset) as UnityEngine.Object;

            if (go == null)
            {
                Dbg.ERROR_MSG(string.Format("资源未创建成功"));
                yield break;
            }
            CoroutineCallBack(go);
            yield break;
        }
    }

    public ResData CreateResData(int resType,int subKey,string path)
    {
        ResData rd;
        rd.resType = resType;
        rd.subKey = subKey;
        rd.pathName = path;

        return rd;
    }
}
