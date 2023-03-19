using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private List<GameObject> targets;
    private EnemySpawner _enemySpawner;
    private Enemy _enemy;
    private int numOfTarget;
    private Animator _anim;
    private float x;
    private float y;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        _enemySpawner = GetComponentInParent<EnemySpawner>();
        targets = _enemySpawner.GetTargets();
        int numOfTarget = Random.Range(0, targets.Count - 1);
        x = 0;
        y = 0;
    }

    private void Update()
    {
        Vector3 direction = Vector3.MoveTowards(transform.position, targets[numOfTarget].transform.position, _enemy.speed * Time.deltaTime);
        float deltaX = direction.x;
        float deltaY = direction.y;

        float ax = targets[numOfTarget].transform.position.x - transform.position.x;
        float ay = targets[numOfTarget].transform.position.y - transform.position.y;

        if (ax > ay)
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
        else if (ax < ay)
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

        transform.position = new Vector2(deltaX, deltaY);

        if (Vector2.Distance(transform.position, targets[numOfTarget].transform.position) < 0.02f)
        {
            numOfTarget = Random.Range(0, targets.Count - 1);
        }
    }
}
