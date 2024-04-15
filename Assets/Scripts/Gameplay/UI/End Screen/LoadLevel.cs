using UnityEngine;
using Zenject;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private SceneField m_mainMenu;

    [Inject]
    private LevelLoader m_levelLoader;

    public void Load()
    {
        m_levelLoader.Load(m_mainMenu);
    }
}
