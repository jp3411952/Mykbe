using UnityEngine;
using DG.Tweening;
using mmowar;
using UnityEngine.EventSystems;

public class ScaleTween : MonoBehaviour {

    public Vector3 scale = new Vector3(1.1f,1.1f,1);
    public Vector3 oldScale;
    public float duration = 0.3f;
    private Sequence se;
    // Use this for initialization
    public  void Start () {
        oldScale = transform.localScale;
        se = DOTween.Sequence();
        se.Append(transform.DOScale(scale, duration /2 )).Append(transform.DOScale(oldScale, duration /2));
        se.SetEase(Ease.OutCubic);
        se.SetAutoKill(false);
        se.Pause();
        UIEventTriggerListener.Get(gameObject).onClick  += PlayTween;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlayTween(PointerEventData eventData)
    {
        se.PlayForward();
        se.Restart();
        
    }
}
