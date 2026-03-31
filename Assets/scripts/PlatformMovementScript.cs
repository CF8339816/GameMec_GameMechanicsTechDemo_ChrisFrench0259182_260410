using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformMovementScript : MonoBehaviour
{
   

    public enum MovementType { Loop, PingPong } 
    [SerializeField] MovementType _movementType; 

    Rigidbody rb;  
    GameObject platform;

    List<Vector3> _platCoords = new List<Vector3>();

    [SerializeField] float _speed; 


    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        foreach (Transform childTransform in this.transform)
        {
            if (!childTransform.CompareTag("PlatCoords"))
            {
                continue;
            }
            _platCoords.Add(childTransform.position);
        }

        if (_platCoords.Count == 0)
        {
            return;
        }
        transform.position = _platCoords[0];
        if (_platCoords.Count > 1)
        {
            StartCoroutine(MoveBetweenWayPoints());
        }

        switch (_movementType)
        {
            case MovementType.Loop:
                StartCoroutine(MoveBetweenWayPoints());
                break;
            case MovementType.PingPong:  
                StartCoroutine(PingPong());
                break;
        }
    }

    IEnumerator MoveBetweenWayPoints() 
    {
        int currentIndex = 0;
        while (true)
        {
            yield return MoveToTarget(_platCoords[currentIndex]); 
            yield return new WaitForSeconds(1.0f);  
            currentIndex = (currentIndex + 1) % _platCoords.Count;
                                                                  
        }
    }

    IEnumerator PingPong() 
    {
        int currentIndex = 0; 
        int direction = 1; 
        while (true)
        {
            yield return MoveToTarget(_platCoords[currentIndex]); 
            yield return new WaitForSeconds(.5f); 

            if (currentIndex == _platCoords.Count - 1) direction = -1;
                                                                     
            else if (currentIndex == 0) direction = 1;
                                                      
            if (currentIndex ==0)
            {
                yield return new WaitForSeconds(3.5f);
            }
            else
            {
                yield return new WaitForSeconds(.5f);
            }
                currentIndex += direction;
        }
    }

    IEnumerator MoveToTarget(Vector3 target)
    {
        while (Vector3.Distance(rb.position, target) > 0.01f)
        {
            Vector3 nextPos = Vector3.MoveTowards(rb.position, target, _speed * Time.deltaTime);
            rb.MovePosition(nextPos); 
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnDrawGizmos()  
    {

        if (Application.isPlaying) return;

        List<Vector3> gizmoWaypoints = new List<Vector3>();
        foreach (Transform child in transform)
        {
            if (child.CompareTag("PlatCoords"))
            {
                gizmoWaypoints.Add(child.position);
            }
        }

        if (gizmoWaypoints.Count == 0) return;

        Gizmos.color = Color.red;

        for (int i = 0; i < gizmoWaypoints.Count; i++)
        {
            Gizmos.DrawSphere(gizmoWaypoints[i], 0.2f);

            if (i < gizmoWaypoints.Count - 1)
            {
                Gizmos.DrawLine(gizmoWaypoints[i], gizmoWaypoints[i + 1]);
            }
        }
    }



}
