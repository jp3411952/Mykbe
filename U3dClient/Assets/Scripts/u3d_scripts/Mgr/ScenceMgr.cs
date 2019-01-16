using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 加载场景管理类
/// </summary>
public class ScenceMgr : MonoBehaviour
{

    public AsyncOperation m_asyncOp;

    // Use this for initialization
    public static ScenceMgr _instance;



    private void Awake()
    {
        _instance = this;
    }


    //读取场景的进度，它的取值范围在0 - 1 之间。
    int progress = 0;
    /// <summary>
    /// 加载开始场景
    /// </summary>
    public void LoadLogoinSence(string sceneName,LoadSceneMode mode)
    {
        StartCoroutine(LoadAsync_progress(sceneName,mode));
    
    }


    IEnumerator AsyncLoadingSence(string sceneName)
    {
        m_asyncOp = SceneManager.LoadSceneAsync(sceneName);
        //阻止当加载完成自动切换  
        m_asyncOp.allowSceneActivation = false;
        yield return m_asyncOp;

        if (!m_asyncOp.isDone)
        {
            Debug.LogError(string.Format("加载场景 ={0}未完成", sceneName));
        }
    }

    private IEnumerator LoadAsync(string sceneName,LoadSceneMode mode)
    {
        m_asyncOp = SceneManager.LoadSceneAsync(sceneName, mode);
        m_asyncOp.allowSceneActivation = false;
        while (!m_asyncOp.isDone && m_asyncOp.progress < 0.8f)
        {
            yield return m_asyncOp;
        }
    }
    private IEnumerator LoadAsync_progress(string sceneName,LoadSceneMode mode)
    {
        m_asyncOp = SceneManager.LoadSceneAsync(sceneName, mode);
        Scene scene = SceneManager.GetSceneByName(sceneName);
        m_asyncOp.allowSceneActivation = false;
        while (m_asyncOp.progress < 0.9f)
        {
            yield return null;
        }
        m_asyncOp.allowSceneActivation = true;
        while (!scene.isLoaded)
        {
            yield return null;
        }
        m_asyncOp = null;
    }
}

