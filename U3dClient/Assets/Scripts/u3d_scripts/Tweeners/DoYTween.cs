using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoYTween : BaseDO {




    public override  void Start () {
        OnInit(m_tagval, m_durationtime, m_isRelat);
    }

    public override void OnInit(float tagval, float durat, bool isrela)
    {
        m_tw = m_rtf.DOLocalMoveY(tagval, durat);
        m_tw.SetEase(Ease.OutCubic);
        m_tw.SetAutoKill(false);
        m_tw.Pause();
    }

    //public override bool OnDoBackwards()
    //{

    //}

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
