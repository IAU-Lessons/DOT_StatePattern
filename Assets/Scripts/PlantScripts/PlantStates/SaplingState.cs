using StateMachine;
using UnityEngine;


public class SaplingState : StateWithTimer
{
    private Transform saplingTransform;
    private Vector3 startScale;
    private Vector3 growedScale;
    
    public SaplingState(float countTime) : base(countTime)
    { }

    public override void EnterState(BaseStateMachine machine)
    {
        machine.PlantStateMachine().SaplingObject.SetActive(true);
        this.saplingTransform = machine.PlantStateMachine().SaplingObject.transform;
        this.startScale = this.saplingTransform.localScale;
        this.growedScale = new Vector3(2, 2, 2);
        base.StartTimer();
    }

    public override void UpdateState(BaseStateMachine machine)
    {
        base.UpdateState(machine);
        Vector3 lerped = Vector3.Lerp(this.startScale, this.growedScale, base.elapsedTime / base.countTime);
        saplingTransform.localScale = lerped;
    }

    public override void LeaveState(BaseStateMachine machine)
    {
        base.LeaveState(machine);
        machine.PlantStateMachine().SaplingObject.SetActive(false);
    }

    protected override void CountDownFinished(BaseStateMachine machine)
    {
        machine.ChangeState(machine.PlantStateMachine().LeafState);
    }

}
