using CptLost.EventBus;
using UnityEngine;

public class PlayerMoveAction : MoveAction
{
    public PlayerMoveAction(GridObject owningObject, GridManager gridManager, Vector3Int gridTargetPosition, float moveSpeed)
        : base(owningObject, gridManager, gridTargetPosition, moveSpeed)
    {

    }

    public override void OnActionStart()
    {
        base.OnActionStart();

        if (!m_isActionValid)
            return;

        EventBus<PlayerMoveEvent>.Invoke(new PlayerMoveEvent(m_cellTargetPosition));
    }
}
