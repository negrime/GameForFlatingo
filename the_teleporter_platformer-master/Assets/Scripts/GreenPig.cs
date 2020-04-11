using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GreenPig : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool _isAlive;
    private void Start()
    {
        _isAlive = true;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!_isAlive)
        {
            return;
        }

        if (GameObject.FindObjectOfType<PlayerController>().isDash)
        {
            _isAlive = false;
            _rigidbody.rotation = Random.Range(30, 180);
            _rigidbody.AddForce(new Vector2(0.5f, 1) * Random.Range(600, 1000));
            GetComponent<Animator>().SetTrigger("Die");
            Destroy(gameObject, 3);
            gameObject.layer = LayerMask.NameToLayer("IgnorePlayer");
        }
        else
        {
            GameObject.FindObjectOfType<PlayerController>().Die();
        }
    }
}
