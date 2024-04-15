using CptLost.EventBus;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class LevelFinisher : MonoBehaviour
{
    [SerializeField]
    private SceneField m_nextLevel;
    [SerializeField]
    private GameObject m_demonPrefab;
    [SerializeField]
    private Transform m_demonSpawnPlace;
    [SerializeField]
    private AudioClip m_endGameSound;

    public UnityEvent OnLevelFinished;

    [Inject]
    private LevelLoader m_levelLoader;
    [Inject]
    private AudioManager m_audioManager;

    public void FinishGame()
    {
        EventBus<LevelFinishedEvent>.Invoke(new LevelFinishedEvent());

        Instantiate(m_demonPrefab, m_demonSpawnPlace.transform.position, Quaternion.identity);

        m_audioManager.PlaySFX(m_endGameSound);

        StartCoroutine(ChangeLevelCoroutine());
    }

    private IEnumerator ChangeLevelCoroutine()
    {
        yield return new WaitForSeconds(2.3f);

        m_levelLoader.Load(m_nextLevel);
    }
}
