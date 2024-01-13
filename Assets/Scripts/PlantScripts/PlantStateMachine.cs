using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStateMachine : BaseStateMachine
{
    
    #region InspectorRefs

    [SerializeField] private GameObject saplingObject;
    [SerializeField] private GameObject leafObject;
    [SerializeField] private GameObject fruitObject;
    
    #endregion InspectorRefs

    #region Getters

    public string CurrentStateName
    {
        get
        {
            return base.currentState.GetType().Name;
        }
    }
    
    public GameObject SaplingObject
    {
        get
        {
            return this.saplingObject;
        }
    }

    public GameObject LeafObject
    {
        get
        {
            return this.leafObject;
        }
    }

    public GameObject FruitObject
    {
        get
        {
            return this.fruitObject;
        }
    }

    #endregion Getters

    #region States

    public SaplingState SaplingState { get; private set; }
    public LeafState LeafState { get; private set; }
    public FruitState FruitState { get; private set; }

    #endregion States
    
    
    void Start()
    {
        this.saplingObject.SetActive(false);
        this.leafObject.SetActive(false);
        this.fruitObject.SetActive(false);
        
        SaplingState = new SaplingState(Random.Range(3f, 10f));
        LeafState = new LeafState(Random.Range(5f, 15f));
        FruitState = new FruitState(Random.Range(30f, 50f));
        
        //set starting state!
        base.currentState = SaplingState;
        base.currentState.EnterState(this);
    }

    void Update()
    {
        base.currentState.UpdateState(this);
    }

    public override void ChangeState(BaseState state)
    {
        base.currentState.LeaveState(this);
        if (state is SaplingState)
        {
            base.currentState = SaplingState;
        }else if (state is LeafState)
        {
            base.currentState = LeafState;
        }else if (state is FruitState)
        {
            base.currentState = FruitState;
        }
        base.currentState.EnterState(this);
    }
}

/// <summary>
/// Extension caster.
/// </summary>
public static class PlantStateMachineCaster
{
    public static PlantStateMachine PlantStateMachine(this BaseStateMachine machine){
        return (PlantStateMachine)machine;
    }
}