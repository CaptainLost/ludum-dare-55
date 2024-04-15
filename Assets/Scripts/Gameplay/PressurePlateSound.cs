using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PressurePlateSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip m_activeSwitchClip;
    [SerializeField]
    private AudioClip m_notActiveSwitchClip;

    private SignalReceiverObject m_receiverObject;
    [Inject]
    private AudioManager m_audioManager;

    private void Awake()
    {
        m_receiverObject = GetComponent<SignalReceiverObject>();
    }

    private void OnEnable()
    {
        m_receiverObject.OnSignalChanged += PlaySound;
    }

    private void OnDisable()
    {
        m_receiverObject.OnSignalChanged -= PlaySound;
    }

    private void PlaySound(bool active)
    {
        if (active)
        {
            m_audioManager.PlaySFX(m_activeSwitchClip);
        }
        else
        {
            m_audioManager.PlaySFX(m_notActiveSwitchClip);
        }
    }
}
