using UnityEngine;

public class StayOnPlatform : MonoBehaviour
{
    private Vector3 lastPlatformPosition;
    private CharacterController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<CharacterController>();
            lastPlatformPosition = transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerController != null)
        {
            Vector3 platformMovement = transform.position - lastPlatformPosition;
                      
            if (platformMovement.magnitude > 0)
            {
                playerController.Move(platformMovement);
            }

            lastPlatformPosition = transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = null;
        }
    }
}