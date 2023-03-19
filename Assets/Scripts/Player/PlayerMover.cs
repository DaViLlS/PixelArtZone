using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private AudioClip walkAudio;
    [SerializeField]  private float _speed;
    [SerializeField] private AudioSource audioClip;
    private Rigidbody2D _playerBody;
    private Animator _anim;
    private float deltaX;
    private float deltaY;
    private bool _alreadyStarted;

    private void Start()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        audioClip.clip = walkAudio;
        _alreadyStarted = false;
    }

    private void Update()
    {
        deltaX = Input.GetAxis("Horizontal") * _speed;
        _anim.SetFloat("Horizontal", deltaX);

        deltaY = Input.GetAxis("Vertical") * _speed;
        _anim.SetFloat("Vertical", deltaY);

        if (Math.Abs(deltaX) > 0 || Math.Abs(deltaY) > 0)
        {
            if (!_alreadyStarted)
            {
                StartCoroutine(StartWalk());
            }
        }
        else if (Math.Abs(deltaX) <= 0 || Math.Abs(deltaY) <= 0)
        {
            audioClip.Stop();
            _alreadyStarted = false;
        }

        _anim.SetFloat("Speed", new Vector3(deltaX, deltaY, 0.0f).magnitude);

        _playerBody.velocity = new Vector2(deltaX, deltaY);
    }

    IEnumerator StartWalk()
    {
        audioClip.Play();
        _alreadyStarted = true;
        yield return new WaitForSeconds(walkAudio.length);
        _alreadyStarted = false;
    }
}
