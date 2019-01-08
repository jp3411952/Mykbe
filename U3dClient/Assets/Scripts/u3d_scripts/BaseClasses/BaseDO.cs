using DG.Tweening;
using System.Collections;
using UnityEngine;

public class BaseDO :MonoBehaviour
{
    public Tweener m_tw;
    protected RectTransform m_rtf;
    /// <summary>
    /// 是否是动画界面
    /// </summary>
    public bool isTweenView = true;
    /// <summary>
    /// 持续时间
    /// </summary>
    public float m_durationtime = 1.0f;

    /// <summary>
    /// 初始位置在屏幕外面
    /// </summary>
    public float m_tagval = 0;
    /// <summary>
    /// 是否是相对坐标
    /// </summary>
    public bool m_isRelat = false;

    public void Awake()
    {
        m_rtf = transform as RectTransform;
    }

    public virtual  void  Start()
    {
        OnInit(m_tagval,m_durationtime,m_isRelat);
    }

    public virtual void OnInit(float tagval, float durat, bool isrela)
    {
             
    }



 

    /// <summary>
    /// 打开
    /// </summary>
    /// <returns></returns>
    public virtual bool OnDoForward()
    {

        gameObject.SetActive(true);
        if (isTweenView)
        {
            m_tw.PlayForward();
        }
      //  m_tw.Restart();
        return true;
    }

    /// <summary>
    /// 关闭
    /// </summary>
    /// <returns></returns>
    public virtual bool OnDoBackwards()
    {
        if (isTweenView)
        {
            m_tw.PlayBackwards();
        }

        StartCoroutine(lazzSetActive(false));
        return true;
    }

    /// <summary>
    /// 延迟设置为false
    /// </summary>
    /// <returns></returns>
    IEnumerator lazzSetActive(bool isActive)
    {
        yield return new WaitForSeconds(m_durationtime);
        gameObject.SetActive(isActive);
    }

}
