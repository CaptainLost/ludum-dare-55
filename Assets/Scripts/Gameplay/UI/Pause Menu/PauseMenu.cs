using CptLost.EventBus;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject m_pauseObject;
    [SerializeField]
    private SceneField m_menuScene;

    [Inject]
    private LevelLoader m_levelLoader;

    private bool m_isLocked;
    private EventBusReceiver<LevelFinishedEvent> m_levelFinishedReceiver;

    private void Start()
    {
        m_levelFinishedReceiver = new EventBusReceiver<LevelFinishedEvent>(LockMenu);

        EventBus<LevelFinishedEvent>.Register(m_levelFinishedReceiver);
    }

    private void OnDestroy()
    {
        EventBus<LevelFinishedEvent>.Unregister(m_levelFinishedReceiver);
    }

    public void SwitchPause()
    {
        if (m_pauseObject.activeInHierarchy)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        if (m_isLocked)
            return;

        m_pauseObject.SetActive(true);

        Time.timeScale = 0f;
    }

    public void CloseMenu()
    {
        m_pauseObject.SetActive(false);

        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        LockMenu();

        Scene currentScene = SceneManager.GetActiveScene();

        m_levelLoader.Load(currentScene.name);
    }

    public void ReturnToMenu()
    {
        LockMenu();

        m_levelLoader.Load(m_menuScene);
    }

    private void LockMenu()
    {
        m_isLocked = true;

        CloseMenu();
    }
}
