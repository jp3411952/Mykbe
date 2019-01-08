using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAnchroTween : BaseDO {



    // Use this for initialization
    public Vector2 anchro = new Vector2(0, 0);

 
    public override void Start () {
        OnInit(m_tagval, m_durationtime, m_isRelat);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnInit(float tagval,float durat,bool isrela)
    {
        m_tw = m_rtf.DOAnchorPos(anchro, durat)/*.From(isrela)*/;
        m_tw.Pause();
        m_tw.SetEase(Ease.OutCubic);
        m_tw.SetAutoKill(false);
       // base.OnDoForward(); //关闭
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    //public override bool OnDoBackwards()
    //{
    //    if (isTweenView)
    //    {
    //        m_tw.PlayBackwards();
    //    }
    //    gameObject.SetActive(false);

    //    return true;
       
    //}

    ///// <summary>
    ///// 打开窗口
    ///// </summary>
    //public override bool OnDoForward()
    //{
    //    gameObject.SetActive(true);
    //    if (isTweenView)
    //    {
    //        transform.DOPlayForward();
    //    }
    //    return true;
    //}
}
