using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _positions;


    public Vector3 GetPosition()
    {
        int value = PlayerPrefs.GetInt("CheckPoint");

        return _positions[value].transform.position;
    }
}
