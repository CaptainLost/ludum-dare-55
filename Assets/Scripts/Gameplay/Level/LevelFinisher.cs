using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class LevelFinisher : MonoBehaviour
{
    [SerializeField]
    private SceneField m_nextLevel;

    public UnityEvent OnLevelFinished;

    [Inject]
    private LevelLoader m_levelLoader;

    public void FinishGame()
    {
        m_levelLoader.Load(m_nextLevel);
    }
}
