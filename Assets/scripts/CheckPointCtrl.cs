using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CheckPointCtrl : MonoBehaviour
{
    public GameObject checkpoint;
    public Transform target;
     playercontroler playerScript;


    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            playerScript = other.GetComponent<playercontroler>();
            if (playerScript != null && target != null)
            {

                playerScript.enabled = false;

                playerScript.ActiveCheckPoint = target;



                playerScript.enabled = true;


            }

        }
    }
}

//if (playerScript.Health == 0 && charCtrlr != null && target != null)
//charCtrlr.enabled = false;

//other.transform.position = target.position;



//charCtrlr.enabled = true;