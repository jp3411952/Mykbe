using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour {
    Camera uiCamera;
    float currentAspet;
    // Use this for initialization
    void Awake()
    {
        uiCamera = GetComponent<Camera>();
        uiCamera.orthographicSize = System.Convert.ToSingle(Screen.height) / 2 / 100;
    }
    void Start () {
        

        //Debug.Log("---------------width" + Screen.width);
        //Debug.Log("---------------height" + Screen.height);
       
        //Debug.Log("---------------orthographicSize" + uiCamera.orthographicSize);
        //Debug.Log("---------------uiCamera.aspect :" + uiCamera.aspect);
    }
	
	// Update is called once per frame
	void Update () {
       
    }
}
