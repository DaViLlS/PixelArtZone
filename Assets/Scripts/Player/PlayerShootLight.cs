using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootLight : MonoBehaviour
{
    private GameObject _shootLight;

    private void Awake()
    {
        _shootLight = gameObject;
    }

    public void StartShootLight()
    {
        _shootLight.SetActive(true);
        StartCoroutine(shootLive());
    }

    IEnumerator shootLive()
    {
        yield return new WaitForSeconds(0.5f);
        _shootLight.SetActive(false);
    }
}
