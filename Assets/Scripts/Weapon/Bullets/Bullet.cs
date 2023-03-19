using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float timeDestroy;
    [SerializeField] protected float speed;
    protected Rigidbody2D rb;
    protected Vector3 difference;
    protected int _damage;

    public abstract void StartFly();
    public abstract void SetDamage(int damage);
    public abstract void DestroyBullet();
    public abstract void SetDamagenTriggerEnter(Collider2D collision);
}
