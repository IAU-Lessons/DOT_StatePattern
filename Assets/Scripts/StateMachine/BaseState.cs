
public abstract class BaseState
{
    public abstract void EnterState(BaseStateMachine machine);
    public abstract void UpdateState(BaseStateMachine machine);
    public abstract void LeaveState(BaseStateMachine machine);
}
