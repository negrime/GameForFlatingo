using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    private int triggerCount;

    [SerializeField]
    private GameObject _gravity;

    [SerializeField]
    private GameObject _dash;

    private bool _showGravity;

    private bool _showDash;

    private PlayerController _player;
    void Start()
    {
        _dash.SetActive(false);
        _gravity.SetActive(false);
        _player = FindObjectOfType<PlayerController>();
        _showGravity = false;
        _showDash = false;
    }

    private void LateUpdate()
    {
        if (_showGravity)
        {
            _gravity.transform.position = new Vector3(_player.transform.position.x + 3, transform.position.y, transform.position.z);
        }
        else if (_showDash)
        {
            _dash.transform.position = new Vector3(_player.transform.position.x + 3, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigegr");
        if (other.gameObject.CompareTag("Player"))
        {
            Trigger();
        }
    }

    private void Trigger()
    {
        triggerCount++;

        if (triggerCount == 1)
        {
            StartCoroutine(ShowGravity());
        }
        else if (triggerCount == 2)
        {
            StartCoroutine(ShowDash());  
        }
    }


    private IEnumerator ShowGravity()
    {
        _gravity.SetActive(true);
        _showGravity = true;
        yield return new WaitForSeconds(4);
        _gravity.SetActive(false);
        _showGravity = false;
    }
    
    private IEnumerator ShowDash()
    {
        _dash.SetActive(true);
        _showDash = true;
        yield return new WaitForSeconds(3);
        _dash.SetActive(false);
        _showDash = false;
    }
}
