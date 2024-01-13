using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    protected BaseState currentState;

    public abstract void ChangeState(BaseState state);
}
