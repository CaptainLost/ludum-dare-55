using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PauseMenuInput : MonoBehaviour
{
    [SerializeField]
    private PauseMenu m_pauseMenu;

    [Inject]
    private InputManager m_inputManager;

    private void OnEnable()
    {
        m_inputManager.InputAsset.Movement.Pause.performed += OnPausePerformed;
    }

    private void OnDisable()
    {
        m_inputManager.InputAsset.Movement.Pause.performed -= OnPausePerformed;
    }

    private void OnPausePerformed(InputAction.CallbackContext context)
    {
        m_pauseMenu.SwitchPause();
    }
}
