using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "States/FollowQuestState")]
public class FollowQuestState : State
{
    [SerializeField] private List<GameObject> targetsToAdd;
    private List<GameObject> targets;
    private NeutralNPC _neutralNpc;
    private Transform _neutralTransform;
    private int numOfTarget;
    private float x;
    private float y;

    public override void Init()
    {
        _neutralNpc = Npc.GetComponent<NeutralNPC>();
        _neutralTransform = Npc.transform;
        targets = targetsToAdd;
        numOfTarget = 0;
        x = 0;
        y = 0;
    }

    public override void Run()
    {
        if (IsFinished)
            return;
        else if (numOfTarget < targets.Count)
        {
            Vector3 direction = Vector3.MoveTowards(_neutralTransform.position,
                targets[numOfTarget].transform.position, _neutralNpc.neutralNpcSO.neutralSpeed * Time.deltaTime);
            float deltaX = direction.x;
            float deltaY = direction.y;

            float ax = targets[numOfTarget].transform.position.x - _neutralTransform.position.x;
            float ay = targets[numOfTarget].transform.position.y - _neutralTransform.position.y;

            if (System.Math.Abs(ax) > System.Math.Abs(ay))
            {
                if (ax > 0)
                {
                    x = 1;
                    y = 0;
                }
                else
                {
                    x = -1;
                    y = 0;
                }
            }
            else if (System.Math.Abs(ax) < System.Math.Abs(ay))
            {
                if (ay > 0)
                {
                    x = 0;
                    y = 1;
                }
                else
                {
                    x = 0;
                    y = -1;
                }
            }

            _neutralTransform.position = new Vector2(deltaX, deltaY);

            if (Vector2.Distance(_neutralTransform.position, targets[numOfTarget].transform.position) < 0.02f)
            {
                if (numOfTarget < targets.Count)
                    numOfTarget++;
            }
        }
        else if (numOfTarget == targets.Count)
        {
            IsFinished = true;
            _neutralNpc.onObjectiveCompleted?.Invoke();
            _neutralNpc.SetState(_neutralNpc.idleState);
        }
    }
}
