using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightRotator : MonoBehaviour
{
    private Vector3 difference;

    private void Update()
    {
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(rotateZ + 180f, -90f, 0f);
    }
}
