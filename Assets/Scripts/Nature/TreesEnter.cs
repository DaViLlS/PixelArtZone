using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TreesEnter : MonoBehaviour
{
    [SerializeField] private Material treesMaterial;
    private Color _treesColor;

    private void Awake()
    {
        _treesColor = treesMaterial.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _treesColor.a = 0.4f;

            treesMaterial.color = _treesColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _treesColor.a = 1f;

            treesMaterial.color = _treesColor;
        }
    }
}
