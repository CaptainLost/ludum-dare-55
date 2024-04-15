using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private LoadScreen m_loadScreen;

    private AsyncOperation m_asyncOperation;

    public void Load(string sceneName)
    {
        if (m_asyncOperation != null)
            return;

        m_loadScreen.HideScreen(() => { LoadInternal(sceneName); });
    }

    private void LoadInternal(string sceneName)
    {
        StartCoroutine(LoadCoroutine(sceneName));
    }

    private IEnumerator LoadCoroutine(string sceneName)
    {
        m_asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!m_asyncOperation.isDone)
        {
            yield return new WaitForSeconds(0.1f);
        }

        m_loadScreen.ShowScreen(null);

        m_asyncOperation = null;
    }
}
