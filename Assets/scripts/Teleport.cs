using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject character;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            CharacterController charCtrlr = other.GetComponent<CharacterController>();
            if (charCtrlr != null && teleportTarget != null)
            {

                charCtrlr.enabled = false;

                other.transform.position = teleportTarget.position;

                other.transform.rotation = teleportTarget.rotation;

                charCtrlr.enabled = true;


            }

        }
    }
}