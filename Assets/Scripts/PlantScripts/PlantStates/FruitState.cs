using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;


public class FruitState : StateWithTimer
{
    private Transform[] trs;
    private Rigidbody[] rbs;
    private List<Vector3> fruitPositions = new List<Vector3>();
    
    public FruitState(float countTime) : base(countTime)
    {
    }

    public override void EnterState(BaseStateMachine machine)
    {
        machine.PlantStateMachine().FruitObject.SetActive(true);
        trs = machine.PlantStateMachine().FruitObject.GetComponentsInChildren<Transform>();
        trs = ResizeForParentObject(trs,machine.PlantStateMachine().FruitObject.transform);
        for (int i = 0; i < trs.Length; i++)
        {
            fruitPositions.Add(trs[i].position);   
        }
        rbs = machine.PlantStateMachine().FruitObject.GetComponentsInChildren<Rigidbody>();
        base.StartTimer();
    }

    public override void UpdateState(BaseStateMachine machine)
    {
        base.UpdateState(machine);
        if (elapsedTime > countTime / 2f)
        {
            foreach (var rb in rbs)
            {
                rb.isKinematic = false;
            }
        }
    }

    public override void LeaveState(BaseStateMachine machine)
    {
        base.LeaveState(machine);
        machine.PlantStateMachine().FruitObject.SetActive(false);
        machine.PlantStateMachine().LeafObject.SetActive(false);
        for (int i = 0; i < fruitPositions.Count; i++)
        {
            trs[i].position = fruitPositions[i];
            rbs[i].isKinematic = true;
        }
    }

    protected override void CountDownFinished(BaseStateMachine machine)
    {
        machine.ChangeState(machine.PlantStateMachine().SaplingState);
    }

    private Transform[] ResizeForParentObject(Transform[] transforms,Transform parent)
    {
        for (int i = 0; i<transforms.Length;i++)
        {
            if (transforms[i].Equals(parent))
            {
                transforms[i] = transforms[transforms.Length - 1];
                Array.Resize(ref transforms, transforms.Length - 1);
                i--;
            }
        }
        return transforms;
    }
    
}
