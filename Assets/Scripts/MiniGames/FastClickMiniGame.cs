using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastClickMiniGame : MonoBehaviour
{
    [SerializeField] public float maxClicks;
    [SerializeField] private float clicksToMinus;
    [SerializeField] private float clicksToPlus;
    public float _currentClicks;
    [SerializeField] public FastClickBar _fastClickUi;
    private bool _canClick;
    private bool _canStart;
    private bool _canMinus;
    public bool isCompleted;

    public Action onObjectiveCompleted;

    private void Awake()
    {
        _currentClicks = maxClicks/2;
        _canClick = false;
        _canStart = false;
        _canMinus = true;
        isCompleted = false;
    }

    private void Start()
    {
        _fastClickUi.SetFasClick(this);
    }

    private void Update()
    {
        if (_canStart)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StartClicking();
            }
        }

        if (_canClick)
        {
            _fastClickUi.UpdateBar();
            StartCoroutine(cickMinus());

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _currentClicks += clicksToPlus;
            }
        }

        if (_currentClicks >= maxClicks)
        {
            isCompleted = true;
            StopClicking();
            Debug.Log("Completed");
        }
        else if (_currentClicks <= 0)
        {
            isCompleted = false;
            StopClicking();
            Debug.Log("Failed");
        }
    }

    private void StartClicking()
    {
        _canClick = true;
        Camera.main.orthographicSize = 3.3f;
        _fastClickUi.gameObject.SetActive(true);
        _fastClickUi._fastClickBorder.gameObject.SetActive(true);
    }

    private void StopClicking()
    {
        _canClick = false;
        Camera.main.orthographicSize = 6.6f;
        _fastClickUi.gameObject.SetActive(false);
        _fastClickUi._fastClickBorder.gameObject.SetActive(false);
        onObjectiveCompleted?.Invoke();
    }

    IEnumerator cickMinus()
    {
        if (_canMinus)
        {
            _fastClickUi.UpdateBar();
            _canMinus = false;
            yield return new WaitForSeconds(0.5f);
            _fastClickUi.UpdateBar();
            _currentClicks -= clicksToMinus;
            _canMinus = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _canStart = true;
        }
    }
}
