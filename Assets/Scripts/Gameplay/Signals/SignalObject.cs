using CptLost.EventBus;

public abstract class SignalObject : GridObject
{
    private EventBusReceiver<ObjectEnterCellEvent> _cellEnterEventReceiver;

    protected override void Awake()
    {
        base.Awake();

        _cellEnterEventReceiver = new EventBusReceiver<ObjectEnterCellEvent>(OnObjectEnterAnyCell);
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        EventBus<ObjectEnterCellEvent>.Register(_cellEnterEventReceiver);
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        EventBus<ObjectEnterCellEvent>.Unregister(_cellEnterEventReceiver);
    }

    protected abstract void OnObjectEnterAnyCell(ObjectEnterCellEvent cellEnterEvent);
}
