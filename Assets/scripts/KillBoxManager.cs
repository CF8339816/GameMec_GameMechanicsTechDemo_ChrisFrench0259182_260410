using UnityEngine;

public class KillBoxManager : MonoBehaviour
{
    public GameObject checkpoint;
    public Transform target;
    playercontroler playerScript;


    void OnTriggerEnter(Collider other)
    {
        playerScript.Health = 0;
        target = playerScript.ActiveCheckPoint;
        if (other.CompareTag("Player"))
        {
            CharacterController charCtrlr = other.GetComponent<CharacterController>();
           

            if (playerScript.Health == 0 && charCtrlr != null && target != null)
                charCtrlr.enabled = false;
           

            other.transform.position = target.position;
            playerScript.Health = 1;


            charCtrlr.enabled = true;

        }
    }
}