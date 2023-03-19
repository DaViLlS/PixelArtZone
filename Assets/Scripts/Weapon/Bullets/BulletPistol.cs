using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPistol : Bullet
{
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartFly();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetDamagenTriggerEnter(collision);
    }

    public override void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    public override void SetDamage(int damage)
    {
        _damage = damage;
    }

    public override void SetDamagenTriggerEnter(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            DestroyBullet();
            enemy.ApplyDamage(_damage);
        }
    }

    public override void StartFly()
    {
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        rb.velocity = transform.right * speed;
        Invoke("DestroyBullet", timeDestroy);
    }
}
