using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FireSwitch : MonoBehaviour
{
    private Animator _animator;
    private Collider2D _collider;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<CapsuleCollider2D>();
        ToggleSwitch(true);
    }

    public void ToggleSwitch(bool on)
    {
        _animator.SetBool("fireOn", on);
        _collider.enabled = on;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("EKWEFWEGWEGWEGW3EGWGE");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

         //   GameObject.FindWithTag("Player").GetComponent<PlayerPlatformerController>().Die();
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("TeleportationOrb"))
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerPlatformerController>().DestroyOrb(collision.gameObject.GetComponent<TeleportationOrb>());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().Die();

    }
}
