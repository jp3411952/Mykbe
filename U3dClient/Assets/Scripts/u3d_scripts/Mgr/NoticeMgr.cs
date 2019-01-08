using UnityEngine;


public class NoticeMgr:MonoBehaviour
{
    public static NoticeMgr _instance;

    private void Awake()
    {
        _instance = this;
       
    }

}
