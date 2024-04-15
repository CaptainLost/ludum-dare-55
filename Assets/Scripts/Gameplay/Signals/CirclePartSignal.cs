using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Zenject;

public class CirclePartSignal : MonoBehaviour
{
    [SerializeField]
    private SignalReceiverObject m_signalReceiver;
    [SerializeField]
    private Light2D m_light;
    [SerializeField]
    private float m_activeLightIntensity;
    [SerializeField]
    private float m_notActiveLightIntensity;
    [SerializeField]
    private float m_lightChangeSpeed;
    [SerializeField]
    private AudioClip m_startSound;

    private float m_targetLightIntensity;

    [Inject]
    private AudioManager m_audioManager;

    private void Start()
    {
        m_light.intensity = m_notActiveLightIntensity;

        UpdateTargetLightIntensity(false);
    }

    private void OnEnable()
    {
        m_signalReceiver.OnSignalChanged += OnSignalChanged;
    }

    private void OnDisable()
    {
        m_signalReceiver.OnSignalChanged -= OnSignalChanged;
    }

    private void Update()
    {
        UpdateLight();
    }

    private void OnSignalChanged(bool signalChanged)
    {
        PlaySound(signalChanged);

        UpdateTargetLightIntensity(signalChanged);
    }

    private void UpdateTargetLightIntensity(bool active)
    {
        m_targetLightIntensity = active ? m_activeLightIntensity : m_notActiveLightIntensity;
    }

    private void UpdateLight()
    {
        m_light.intensity = Mathf.MoveTowards(m_light.intensity, m_targetLightIntensity, m_lightChangeSpeed * Time.deltaTime);
    }

    private void PlaySound(bool active)
    {
        if (active)
        {
            m_audioManager.PlaySFX(m_startSound);
        }
    }
}
