using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarkaTrigger : MonoBehaviour
{
    [SerializeField] private Anmaly _anomaly;
    private ParticleSystem[] jarkaParticles;
    private Light _light;

    private void Awake()
    {
        jarkaParticles = new ParticleSystem[2];
        jarkaParticles = GetComponentsInChildren<ParticleSystem>();
        _light = GetComponentInChildren<Light>();

        jarkaParticles[0].Play();
        _light.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            jarkaParticles[1].Play();
            _light.gameObject.SetActive(true);
            player.GetDamage(_anomaly.damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            StartCoroutine(activatedJarka());
    }

    IEnumerator activatedJarka()
    {
        yield return new WaitForSeconds(4);
        jarkaParticles[1].Stop();
        _light.gameObject.SetActive(false);
    }
}
