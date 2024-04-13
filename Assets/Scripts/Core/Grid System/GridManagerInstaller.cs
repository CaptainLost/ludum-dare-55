using UnityEngine;
using Zenject;

public class GridManagerInstaller : MonoInstaller
{
    [SerializeField]
    private GridManager m_gridManager;

    public override void InstallBindings()
    {
        Container.Bind<GridManager>().FromInstance(m_gridManager);
    }
}
