using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player player;
    private float damping = 1.5f;
    private Vector2 offset = new Vector2(2f, 1f);

    private void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
    }

    private void Update()
    {
        Vector3 target;
        target = new Vector3(player.GetPosition().x, player.GetPosition().y, -10f);
        Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
        transform.position = currentPosition;
    }
}
