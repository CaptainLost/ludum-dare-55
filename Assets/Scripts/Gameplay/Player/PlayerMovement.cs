using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 5f;

    [Inject]
    private GridManager m_gridManager;

    private void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            Move(new Vector3Int(1, 0, 0));
        }
    }

    public void Move(Vector3Int moveInput)
    {
        m_gridManager.PlayerDatabase.LoopThroughtAllObjects(
            (gridObject) =>
            {
                Vector3Int targetPosition = gridObject.GridObjectData.GridPosition + moveInput;

                MoveAction moveAction = new MoveAction(gridObject, targetPosition, m_moveSpeed);

                gridObject.RequestAction(moveAction);
            });
    }
}
