using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityTrigger : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private Anmaly _anomaly;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _anim.SetBool("isTriggered", true);
            player.GetDamage(_anomaly.damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _anim.SetBool("isTriggered", false);
        }
    }
}
