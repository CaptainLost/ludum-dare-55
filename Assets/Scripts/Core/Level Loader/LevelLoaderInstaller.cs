using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelLoaderInstaller : MonoInstaller
{
    [SerializeField]
    private LevelLoader m_levelLoader;

    public override void InstallBindings()
    {
        Container.Bind<LevelLoader>().FromInstance(m_levelLoader);
    }
}
