using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/ChaseState")]
public class ChaseState : State
{
    private Enemy _enemy;
    private Animator _anim;
    private Transform _enemyTransform;
    private float x;
    private float y;
    private Player _player;
    private float _timeToHit;
    private float _spendedTime;

    public override void Init()
    {
        _anim = Npc.GetComponent<Animator>();
        _enemy = Npc.GetComponent<Enemy>();
        _enemyTransform = Npc.transform;
        _timeToHit = 1;
        _spendedTime = 0f;
    }

    public override void Run()
    {
        if (IsFinished)
            return;
        else
        {
            if (_player.GetComponent<PlayerHealth>().GetHealth() <= 0)
            {
                IsFinished = true;
                return;
            }
            Vector3 direction = Vector3.MoveTowards(_enemyTransform.position, _player.transform.position, (_enemy.speed * 2) * Time.deltaTime);
            float deltaX = direction.x;
            float deltaY = direction.y;

            float ax = _player.transform.position.x - _enemyTransform.position.x;
            float ay = _player.transform.position.y - _enemyTransform.position.y;

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

            if (Vector2.Distance(_enemyTransform.position, _player.transform.position) < 1f)
            {
                if (_spendedTime <= 0)
                {
                    _player.GetDamage(_enemy.Hit());
                    _spendedTime = _timeToHit;
                }
                else
                    _spendedTime -= Time.deltaTime;
            }
        }
    }

    public override void SetPlayer(Player player)
    {
        _player = player;
    }
}
