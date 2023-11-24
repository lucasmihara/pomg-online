using System.Collections.Specialized;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
using Unity.Netcode;
using System;

public class BallPhysics : NetworkBehaviour
{
    private Rigidbody _rigidbody;

    private float _speed = 5f;

    public short lastHit;

    public bool isTemporary; // Temporary balls are the ones created by items / powerups

    private Vector3 _lastVelocity;

    public AudioClip _audioClip;

    public AudioSource _audioSource;

    private int transpose = -4;

    // Start is called before the first frame update
    void Start()
    {
        lastHit = -1;
        _speed = 5f;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = new Vector3(Random.Range(-1, 1) >= 0 ? 1 : -1, Random.Range(0.2f, 0.8f), 0) * _speed;
        // Debug.Log(_rigidbody.velocity);

        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.loop = false;
            _audioSource.clip = _audioClip;
            _audioSource.volume = 1;
        }
    }

    private void Update()
    {
        _lastVelocity = _rigidbody.velocity;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        var reflect = Vector2.Reflect(_lastVelocity, collision.contacts[0].normal).normalized * _speed;

        //Debug.Log(_lastVelocity);
        //Debug.Log(collision.contacts[0].normal);
        //Debug.Log(reflect);
        _rigidbody.velocity = reflect;

        _speed += 0.2f;

        if(collision.gameObject.name == "LeftGoal")
            lastHit = 0; // Left Goal
        else
            lastHit = 1; // Right Goal

        _audioSource.pitch = (float)Math.Pow(2, (transpose + (int)Random.Range(0, 14)) / 12.0);
        _audioSource.Play();
    }

    public void ResetBall()
    {
        if(!isTemporary)
        {
            // Wait for X seconds, then release the ball
            _rigidbody.position = Vector3.zero;
            _rigidbody.velocity = Vector3.zero;

            StartCoroutine(waiter(3));
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator waiter(int seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        Start();
    }
}
