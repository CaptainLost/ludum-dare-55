using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelFinisher : MonoBehaviour
{
    [SerializeField]
    private List<SignalReceiverObject> m_gameFinisherSignals;
    [SerializeField]
    private SceneField m_nextLevel;

    public UnityEvent OnLevelFinished;

    [Inject]
    private LevelLoader m_levelLoader;
    private int m_activeSignals = 0;

    private void OnEnable()
    {
        RegisterSignalEvents();
    }

    private void OnDisable()
    {
        UnregisterSignalEvents();
    }

    private void RegisterSignalEvents()
    {
        foreach (SignalReceiverObject receiver in m_gameFinisherSignals)
        {
            receiver.OnSignalChanged += OnAnySignalUpdated;
        }
    }

    private void UnregisterSignalEvents()
    {
        foreach (SignalReceiverObject receiver in m_gameFinisherSignals)
        {
            receiver.OnSignalChanged -= OnAnySignalUpdated;
        }
    }

    private void OnAnySignalUpdated(bool active)
    {
        if (active)
        {
            m_activeSignals++;
        }
        else
        {
            m_activeSignals--;
        }

        if (m_activeSignals >= m_gameFinisherSignals.Count)
        {
            OnLevelFinished?.Invoke();

            SceneManager.LoadScene(m_nextLevel);
        }
    }
}
