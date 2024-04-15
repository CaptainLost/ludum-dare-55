using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalValidator : MonoBehaviour
{
    [SerializeField]
    private List<SignalReceiverObject> m_signalReceivers;
    [SerializeField]
    private UnityEvent m_onAllSignalsReceived;
    [SerializeField]
    private UnityEvent m_onSignalLost;

    private int m_activeSignals = 0;
    private bool m_active;

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
        foreach (SignalReceiverObject receiver in m_signalReceivers)
        {
            receiver.OnSignalChanged += OnAnySignalUpdated;
        }
    }

    private void UnregisterSignalEvents()
    {
        foreach (SignalReceiverObject receiver in m_signalReceivers)
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

            if (m_active)
            {
                m_onSignalLost?.Invoke();
            }
        }

        if (m_activeSignals >= m_signalReceivers.Count)
        {
            m_onAllSignalsReceived?.Invoke();

            m_active = true;
        }
    }
}
