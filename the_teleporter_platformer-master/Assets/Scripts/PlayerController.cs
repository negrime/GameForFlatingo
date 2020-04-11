using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Vector2 movement;


    public bool isDash;
    
    public ParticleSystem _onRunParticleSystem;

    public bool isGround = true;

    private bool isAlive;


    private bool _canDash;


    [SerializeField]
    private float _startGravityScale;

    [SerializeField]
    private float _startSpeed;
    
    [SerializeField]
    private float _reloadDashTime;

    [SerializeField]
    private float _currentSpeed;


    private bool isBoost;


    private void Awake()
    {
        PlayerPrefs.SetInt("CheckPoint", 0);
    }

    void Start()
    {

        Cursor.visible = false;

        isBoost = false;
        
        transform.position = GetComponent<StartPosition>().GetPosition();
        _currentSpeed = _startSpeed;
        
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        isAlive = false;
        isDash = false;
        _canDash = true;

        StartCoroutine(StartDelay());
    }

    // Update is called once per frame
    void Update()
    {
       if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGround && isAlive)
       { 
           _rigidbody.gravityScale *=  -1;
           VerticalFlip();
           isGround = false;
           _onRunParticleSystem.Stop();
           _animator.SetBool("Grounded", false);
       }

       if (Input.GetMouseButtonDown(1) && isAlive && _canDash)
       {
           StartCoroutine(Dash());
           StartCoroutine(DashReload());
       }
    }


    private IEnumerator StartDelay()
    { 
        yield return  new WaitForSeconds(1);
        isAlive = true;
        _onRunParticleSystem.Play();
        _animator.SetTrigger("Run");
    }
    private IEnumerator Dash()
    {
        _canDash = false;
        _animator.SetBool("Dash", true);
        isDash = true;
        _rigidbody.AddForce(new Vector2(1, 0) * 3500, ForceMode2D.Force);
        yield return new WaitForSeconds(0.3f);
        isDash = false;
        _animator.SetBool("Dash", false);
    }

    private IEnumerator DashReload()
    {
        yield return new WaitForSeconds(_reloadDashTime);
        _canDash = true;
    }
    
    private void FixedUpdate()
    { 
        if ( isAlive)
            _rigidbody.velocity = new Vector3(1 * _currentSpeed, 0, 0) ;
    }

    private void VerticalFlip()
    { 
        transform.localScale = new Vector3(1, transform.localScale.y * -1, 1);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null)
        {
            isGround = true;
            _animator.SetBool("Grounded", true);
            _onRunParticleSystem.Play();
        }
    }

    public void Die()
    {
        if (!isAlive)
        {
            return;
        }
        isAlive = false;
        _animator.SetTrigger("Dead");
        _rigidbody.rotation = Random.Range(30, 180);
       _rigidbody.gravityScale = 1;
        _rigidbody.AddForce(Vector2.up * 1000);
        
        GetComponent<RestartGame>().Restart();
    }


    public void Boost()
    {
        if (isBoost)
            return;
        isBoost = true;
        _currentSpeed += 2 * 6;
        _rigidbody.gravityScale += 5 * 6;
    }
}
