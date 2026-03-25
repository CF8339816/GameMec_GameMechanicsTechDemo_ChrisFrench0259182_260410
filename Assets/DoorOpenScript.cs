using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DoorOpenScript : MonoBehaviour
{
    public GameObject Door;

    public float doorHeight = 5.0f; // how hight is open
    public float speed = 5.0f;
    private Vector3 _closedPos;
    private Vector3 _openPos;
    private Vector3 _targetPos;
    private void Start()
    {
        // Store the starting position and calculate the "up" position
        _closedPos = Door.transform.position;
        _openPos = _closedPos + Vector3.up * doorHeight;
        _targetPos = _closedPos;
    }
    private  void Update()
    {
        Door.transform.position = Vector3.Lerp(Door.transform.position,_targetPos, speed * Time.deltaTime);

    }

        void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _targetPos = _openPos;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          _targetPos = _closedPos;
        }
    }

}
