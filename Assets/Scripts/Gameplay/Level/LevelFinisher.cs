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

    public UnityEvent OnLevelFinished;

    [Inject]
    private LevelLoader m_levelLoader;

    public void FinishGame()
    {
        Instantiate(m_demonPrefab, m_demonSpawnPlace.transform.position, Quaternion.identity);

        StartCoroutine(ChangeLevelCoroutine());
    }

    private IEnumerator ChangeLevelCoroutine()
    {
        yield return new WaitForSeconds(2f);

        m_levelLoader.Load(m_nextLevel);
    }
}
