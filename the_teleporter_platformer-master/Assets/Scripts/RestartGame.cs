using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    private bool isReadyToRestart;

    [SerializeField]
    private Text _restartText;

    private void Start()
    {
        isReadyToRestart = false;
    }

    public void Restart()
    {
        isReadyToRestart = true;
        _restartText.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!isReadyToRestart)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
