using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [Inject]
    private GridManager m_gridManager;

    public void Move(Vector3Int moveInput)
    {
        m_gridManager.PlayerDatabase.LoopThroughtAllObjects(
            (gridObject) =>
            {
                Vector3Int targetPosition = gridObject.GridObjectData.GridPosition + moveInput;
            });
    }
}
