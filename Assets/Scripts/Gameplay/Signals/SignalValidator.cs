using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalValidator : MonoBehaviour
{
    [SerializeField]
    protected List<SignalReceiverObject> m_signalReceivers;
    [SerializeField]
    protected UnityEvent m_onAllSignalsReceived;
    [SerializeField]
    protected UnityEvent m_onSignalLost;

    protected int m_activeSignals = 0;
    protected bool m_active;

    protected void OnEnable()
    {
        RegisterSignalEvents();
    }

    protected void OnDisable()
    {
        UnregisterSignalEvents();
    }

    protected void RegisterSignalEvents()
    {
        foreach (SignalReceiverObject receiver in m_signalReceivers)
        {
            receiver.OnSignalChanged += OnAnySignalUpdated;
        }
    }

    protected void UnregisterSignalEvents()
    {
        foreach (SignalReceiverObject receiver in m_signalReceivers)
        {
            receiver.OnSignalChanged -= OnAnySignalUpdated;
        }
    }

    protected virtual void OnAnySignalUpdated(bool active)
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

                m_active = false;
            }
        }

        if (m_activeSignals >= m_signalReceivers.Count)
        {
            m_onAllSignalsReceived?.Invoke();

            m_active = true;
        }
    }
}
