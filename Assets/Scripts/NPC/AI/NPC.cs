using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    public State StartState;
    public State CurrentState;

    public abstract void SetState(State state);
}
