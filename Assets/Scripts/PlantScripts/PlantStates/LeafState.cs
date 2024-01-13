using StateMachine;
using UnityEngine;


public class LeafState : StateWithTimer
{
    private Transform leafTransform;
    private Vector3 startScale;
    private Vector3 growedScale;
    
    public LeafState(float countTime) : base(countTime)
    { }

    public override void EnterState(BaseStateMachine machine)
    {
        machine.PlantStateMachine().LeafObject.SetActive(true);
        this.leafTransform = machine.PlantStateMachine().LeafObject.transform;
        this.startScale = this.leafTransform.localScale;
        this.growedScale = new Vector3(2, 2, 2);
        base.StartTimer();
    }

    public override void UpdateState(BaseStateMachine machine)
    {
        base.UpdateState(machine);
        Vector3 lerped = Vector3.Lerp(startScale, growedScale, elapsedTime / countTime);
        this.leafTransform.localScale = lerped;
    }

    public override void LeaveState(BaseStateMachine machine)
    {
        base.LeaveState(machine);
    }

    protected override void CountDownFinished(BaseStateMachine machine)
    {
        machine.ChangeState(machine.PlantStateMachine().FruitState);
    }
}
