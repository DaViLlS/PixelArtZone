using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/WalkState")]
public class WalkState : State
{
    private List<GameObject> targets;
    private EnemySpawner _enemySpawner;
    private Enemy _enemy;
    private int numOfTarget;
    private Animator _anim;
    private Transform _enemyTransform;
    private float x;
    private float y;

    public override void Init()
    {
        _anim = Npc.GetComponent<Animator>();
        _enemy = Npc.GetComponent<Enemy>();
        _enemyTransform = Npc.transform;
        _enemySpawner = Npc.GetComponentInParent<EnemySpawner>();
        targets = _enemySpawner.GetTargets();
        x = 0;
        y = 0;
    }

    public override void Run()
    {
        if (IsFinished)
            return;
        else
        {
            Vector3 direction = Vector3.MoveTowards(_enemyTransform.position, targets[numOfTarget].transform.position, _enemy.speed * Time.deltaTime);
            float deltaX = direction.x;
            float deltaY = direction.y;

            float ax = targets[numOfTarget].transform.position.x - _enemyTransform.position.x;
            float ay = targets[numOfTarget].transform.position.y - _enemyTransform.position.y;

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
            _anim.SetFloat("Horizontal", x);
            _anim.SetFloat("Vertical", y);

            _anim.SetFloat("Speed", direction.magnitude);

            _enemyTransform.position = new Vector2(deltaX, deltaY);

            if (Vector2.Distance(_enemyTransform.position, targets[numOfTarget].transform.position) < 0.02f)
            {
                numOfTarget = Random.Range(0, targets.Count - 1);
            }
        }
    }

    public override void Stop()
    {
        IsFinished = true;
        _anim.SetFloat("Speed", 0f);
    }
}