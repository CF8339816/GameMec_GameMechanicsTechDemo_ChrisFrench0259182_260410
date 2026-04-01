using UnityEngine;

public class StayOnPlatform : MonoBehaviour
{
    public GameObject platform;
    public GameObject character;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
            // character.transform = platform.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
     
        if (other.CompareTag("Player"))
        {

            other.transform.SetParent(null);
            // character.transform
        }
    }

}
