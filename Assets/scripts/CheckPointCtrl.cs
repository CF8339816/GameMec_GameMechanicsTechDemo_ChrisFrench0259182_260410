using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CheckPointCtrl : MonoBehaviour
{
   // public GameObject checkpoint;
    public Transform target;
    


    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            playercontroler playerScript = other.GetComponent<playercontroler>();

            if (playerScript != null)
               // if (playerScript != null && target != null)
            {

                //playerScript.enabled = false;

                playerScript.ActiveCheckPoint = target;



                //playerScript.enabled = true;


            }

        }
    }
}

