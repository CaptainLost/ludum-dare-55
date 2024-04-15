using UnityEngine;
using Zenject;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SceneField m_firstLevel;

    [Inject]
    private LevelLoader m_levelLoader;

    public void StartGame()
    {
        m_levelLoader.Load(m_firstLevel);
    }

    public void LoadLevel(SceneField sceneField)
    {
        m_levelLoader.Load(sceneField);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
