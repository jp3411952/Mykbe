
using UnityEngine;
using DG.Tweening;

public class MainCamera : MonoBehaviour {


    private Transform m_cameraTs;
    public DoXTween dox;

    private void Awake()
    {
        m_cameraTs = Camera.main.transform;
        
    }

    private void OnEnable()
    {

        float angle = 0.0f;
        Vector3 axis = Vector3.zero;
        m_cameraTs.rotation.ToAngleAxis(out angle, out axis);

        Debug.Log("角度" + angle);
        Debug.Log(string.Format("x ={0} ,y= {1} ,z = {2}", axis.x,axis.y,axis.z));

    }
    private void Start()
    {
       
    }

    public void ShakeSkin(float sec)
    {
        m_cameraTs.DOShakePosition(sec);
        m_cameraTs.DOShakeScale(sec);
    }
 
}
