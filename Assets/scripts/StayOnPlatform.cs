using UnityEngine;

public class StayOnPlatform : MonoBehaviour
{
    public GameObject platform;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        
            other.transform.SetParent(platform.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
     
        if (other.CompareTag("Player"))
        {
              other.transform.SetParent(null);
        }
    }

}
