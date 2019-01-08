using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AphaTween : BaseDO {


    public Image m_Imgbg;
  
    public override void Start () {
        OnInit(m_tagval, m_durationtime, m_isRelat);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnInit(float tagval, float durat, bool isrela)
    {
      
        m_tw = m_Imgbg.DOFade(tagval, durat);
        m_tw.SetEase(Ease.OutCubic);
        m_tw.SetAutoKill(false);
        m_tw.Pause();
    }

    /// <summary>
    /// 关闭窗口
    /// </summary>
    public override bool OnDoBackwards()
    {
        if (isTweenView)
        {
            m_tw.PlayBackwards();
        }

        return true;
    }

    /// <summary>
    /// 打开窗口
    /// </summary>
    public override bool OnDoForward()
    {
        if (isTweenView)
        {
            transform.DOPlayForward();
        }
        return true;
    }
}
