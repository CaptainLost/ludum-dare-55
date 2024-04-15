using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelFinisher : MonoBehaviour
{
    [SerializeField]
    private List<SignalReceiverObject> m_gameFinisherSignals;

    public UnityEvent OnLevelFinished;

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
            Debug.Log("Level finished");
        }
    }
}
