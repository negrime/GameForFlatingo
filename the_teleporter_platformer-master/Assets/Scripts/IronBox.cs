using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class IronBox : MonoBehaviour
{
    private Rigidbody2D[] _breaks;
    void Start()
    {
        _breaks = GetComponentsInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D other)
    {

        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        
        if (GameObject.FindObjectOfType<PlayerController>().isDash )
        {


            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            foreach (var item in _breaks)
            {
                item.simulated = true;
                item.GetComponent<SpriteRenderer>().enabled = true;
                item.rotation = Random.Range(30, 180);
                item.AddForce(Random.insideUnitCircle * Random.Range(400, 800));
            }
            Destroy(gameObject, 5);
        }
        else
        {
            GameObject.FindObjectOfType<PlayerController>().Die();
        }
    }
}
