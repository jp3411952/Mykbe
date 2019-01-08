using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoXTween : BaseDO {



    // Use this for initialization



    public override void Start () {
        OnInit(m_tagval, m_durationtime, m_isRelat);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnInit(float tagval,float durat,bool isrela)
    {
        m_tw = transform.DOLocalMoveX(tagval, durat);
        m_tw.SetEase(Ease.OutCubic);
        m_tw.SetAutoKill(false);
        m_tw.Pause();
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
