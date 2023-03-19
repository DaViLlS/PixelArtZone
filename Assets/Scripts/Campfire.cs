using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    [SerializeField] ParticleSystem smoke;
    [SerializeField] ParticleSystem sparks;

    private void Awake()
    {
        smoke.Play();
        sparks.Play();
    }
}
