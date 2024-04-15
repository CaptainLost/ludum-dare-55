using System.Collections.Generic;
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
                TryMoveAndPush(gridObject, moveInput);
            });
    }

    private bool TryMoveAndPush(GridObject gridObject, Vector3Int moveInput)
    {
        if (gridObject.HasActionActive())
            return false;

        Vector3Int targetPosition = gridObject.GridObjectData.GridPosition + moveInput;

        if (gridObject.HasFlag(EGridObjectFlags.Dynamic_Collision))
        {
            List<GridObject> objectsAtTarget = m_gridManager.GetObjectsAtCell(targetPosition);

            foreach (GridObject testedObject in objectsAtTarget)
            {
                if (!testedObject.HasFlag(EGridObjectFlags.Dynamic_Collision))
                    continue;

                if (!testedObject.HasFlag(EGridObjectFlags.Pushable))
                    return false;

                if (!TryMoveAndPush(testedObject, moveInput))
                    return false;
            }
        }

        MoveAction moveAction = new MoveAction(gridObject, m_gridManager, targetPosition, m_moveSpeed);

        return gridObject.RequestAction(moveAction);
    }
}
