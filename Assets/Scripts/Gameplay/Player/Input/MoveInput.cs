using UnityEngine;
using Zenject;

public class MoveInput : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement m_playerMovement;

    [Inject]
    private InputManager m_inputManager;

    private void Update()
    {
        Vector2 moveInput = m_inputManager.InputAsset.Movement.Move.ReadValue<Vector2>();

        int inputX = Mathf.RoundToInt(moveInput.x);
        int inputY = Mathf.RoundToInt(moveInput.y);

        if (moveInput.x != 0f || moveInput.y != 0f)
        {
            m_playerMovement.Move(new Vector3Int(inputX, inputY, 0));
        }
    }
}
