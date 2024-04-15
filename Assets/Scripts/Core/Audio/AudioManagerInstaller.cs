using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AudioManagerInstaller : MonoInstaller
{
    [SerializeField]
    private AudioManager m_audioManager;

    public override void InstallBindings()
    {
        Container.Bind<AudioManager>().FromInstance(m_audioManager);
    }
}
