using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 5f;

    [Inject]
    private GridManager m_gridManager;

    public void Move(Vector3Int moveInput)
    {
        m_gridManager.PlayerDatabase.LoopThroughtAllObjects(
            (gridObject) =>
            {
                Vector3Int targetPosition = gridObject.GridObjectData.GridPosition + moveInput;

                PlayerMoveAction moveAction = new PlayerMoveAction(gridObject, m_gridManager, targetPosition, m_moveSpeed);

                gridObject.RequestAction(moveAction);
            });
    }
}
