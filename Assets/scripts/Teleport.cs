using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject character;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            character.transform.position = teleportTarget.transform.position;

            //if (destination != null)
            //{

            //    other.transform.position = destination.position;
            //}
        }
    }
    }