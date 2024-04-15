using CptLost.EventBus;

public abstract class SignalObject : GridObject
{
    private EventBusReceiver<ObjectEnterCellEvent> _cellEnterEventReceiver;
    private EventBusReceiver<ObjectLeaveCellEvent> _cellLeaveEventReceiver;

    protected override void Awake()
    {
        base.Awake();

        _cellEnterEventReceiver = new EventBusReceiver<ObjectEnterCellEvent>(OnObjectEnterAnyCell);
        _cellLeaveEventReceiver = new EventBusReceiver<ObjectLeaveCellEvent>(OnObjectLeaveAnyCell);
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        EventBus<ObjectEnterCellEvent>.Register(_cellEnterEventReceiver);
        EventBus<ObjectLeaveCellEvent>.Register(_cellLeaveEventReceiver);
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        EventBus<ObjectEnterCellEvent>.Unregister(_cellEnterEventReceiver);
        EventBus<ObjectLeaveCellEvent>.Unregister(_cellLeaveEventReceiver);
    }

    protected abstract void OnObjectEnterAnyCell(ObjectEnterCellEvent cellEnterEvent);
    protected abstract void OnObjectLeaveAnyCell(ObjectLeaveCellEvent cellEnterEvent);
}
