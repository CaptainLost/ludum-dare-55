public class SignalValidatorAny : SignalValidator
{
    protected override void OnAnySignalUpdated(bool active)
    {
        if (active)
        {
            m_activeSignals++;
        }
        else
        {
            m_activeSignals--;
        }

        if (m_activeSignals > 0)
        {
            m_onAllSignalsReceived?.Invoke();
        }
        else
        {
            m_onSignalLost?.Invoke();
        }
    }
}
