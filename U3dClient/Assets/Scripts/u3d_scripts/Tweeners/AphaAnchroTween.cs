using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AphaAnchroTween : MonoBehaviour {

    public Vector2 anchrPos = new Vector2(0, 20);
    public Image m_Imgbg;
    public Text m_text;
    private Tweener m_AphaBgTween;
    private Tweener m_AphaTextTween;

    private Tweener m_AncroTween;
    private RectTransform m_rtf;
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

    private void Awake()
    {
        m_rtf = transform as RectTransform;
    }

    // Use this for initialization
    public void Start()
    {
        OnInit();
        // Update is called once per frame
		
	}

    public  void OnInit()
    {
        UIMgr.Instance.GetOrAddComponent<CanvasGroup>(gameObject);
        m_AphaBgTween = m_Imgbg.DOFade(m_tagval, m_durationtime);
        m_AphaTextTween = m_text.DOFade(m_tagval, m_durationtime);
        m_AncroTween = m_rtf.DOAnchorPos(anchrPos, m_durationtime)/*.From(m_isRelat)*/;
        m_AphaBgTween.SetEase(Ease.OutCubic);
        m_AncroTween.SetEase(Ease.OutCubic);
        m_AphaTextTween.SetEase(Ease.OutCubic);
        m_AphaBgTween.SetAutoKill(false);
        m_AphaTextTween.SetAutoKill(false);
        m_AncroTween.SetAutoKill(false);

    }

    /// <summary>
    /// 关闭窗口
    /// </summary>


    /// <summary>
    /// 每次都从零飘动
    /// </summary>
    public  bool OnDoForward()
    {
      
        // m_AphaTween.Pause();

        m_AphaBgTween.PlayForward();
        m_AphaTextTween.PlayForward();
        m_AncroTween.PlayForward();
        StartCoroutine(lazzSetActive(false));
        TweenerRestart();
        return true;
    }


    public bool TweenerRestart()
    {
        m_AphaBgTween.Restart();
        m_AphaTextTween.Restart();
        m_AncroTween.Restart();
         
        return true;
    }

    /// <summary>
    /// 延迟设置为false
    /// </summary>
    /// <returns></returns>
    IEnumerator lazzSetActive(bool isActive)
    {
        yield return new WaitForSeconds(m_durationtime);

        m_AphaBgTween.PlayBackwards();
        m_AphaTextTween.PlayBackwards();
        m_AncroTween.PlayBackwards();
        gameObject.SetActive(isActive);
    }
}
