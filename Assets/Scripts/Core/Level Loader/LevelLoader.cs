using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private LoadScreen m_loadScreen;

    public void Load(string sceneName)
    {
        m_loadScreen.HideScreen(() => { LoadInternal(sceneName); });
    }

    private void LoadInternal(string sceneName)
    {
        StartCoroutine(LoadCoroutine(sceneName));
    }

    private IEnumerator LoadCoroutine(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            yield return new WaitForSeconds(0.1f);
        }

        m_loadScreen.ShowScreen(null);
    }
}
