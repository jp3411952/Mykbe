using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 携程管理，MonoBehaviour 携程失效
/// </summary>
public class CoroutineMgr
{

    public static CoroutineMgr _instance;

    static CoroutineMgr()
    {
        _instance  = new CoroutineMgr();
    }

    //public static CoroutineMgr Instance
    //{
    //    get { return _instance; }
    //    private set { } 
    //}

    private MonoBehaviour  uiloadCoroutine;
    /// <summary>
    /// ui携程
    /// </summary>
    public MonoBehaviour m_UiloadCoroutine
    {
        get{ return uiloadCoroutine;}
    }


    private MonoBehaviour uiCoroutine;
    /// <summary>
    /// ui携程
    /// </summary>
    public MonoBehaviour m_UiCoroutine
    {
        get { return uiCoroutine; }
    }

    private MonoBehaviour goCoroutine;
    public MonoBehaviour m_goCoroutine
    {
        get { return goCoroutine; }
    }

    //记得要先创建
    public void OnInit()
    {
        if (uiloadCoroutine == null)
            uiloadCoroutine = new MonoBehaviour();
        if (goCoroutine == null)
            goCoroutine = new MonoBehaviour();
        if (uiCoroutine)
            uiCoroutine = new MonoBehaviour();
    }
  
}
