using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private Vector3 _mousePos;
    private Grid<string> _grid;

    private void Start()
    {
        _grid = new Grid<string>(4, 4, 1f, Vector3.zero);

        List<bool> boolList = new List<bool>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(1))
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(_grid.GetValue(_mousePos));
        }
    }
}
