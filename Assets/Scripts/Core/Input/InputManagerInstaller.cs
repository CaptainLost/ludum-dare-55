using UnityEngine;
using Zenject;

public class InputManagerInstaller : MonoInstaller
{
    [SerializeField]
    private InputManager m_inputManager;

    public override void InstallBindings()
    {
        Container.Bind<InputManager>().FromInstance(m_inputManager);
    }
}
