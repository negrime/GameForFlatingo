using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }

        FindObjectOfType<PlayerController>().Boost();
        Destroy(gameObject);
    }
}
