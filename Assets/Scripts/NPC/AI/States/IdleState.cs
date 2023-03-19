using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/IdleState")]
public class IdleState : State
{
    public override void Init()
    {
      
    }

    public override void Run()
    {
        if (IsFinished)
            return;
        else
        {

        }
    }
}
