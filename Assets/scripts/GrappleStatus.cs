using UnityEngine;
using TMPro; 

public class GrappleStatus : MonoBehaviour
{
    private playercontroler playerScript; 
    public TMPro.TextMeshProUGUI textGrappleGun;
    public Camera firstPersonCam;
    public Camera grappleCamera;
   // public GameObject GrappleSpooger;
    void Update()
    {
        SetTextGrappleGun();
    }

    public void SetTextGrappleGun()
    {
       
        if (playerScript != null)
        {
            if (playerScript.PowerOn == true)
            {
                textGrappleGun.text = "Grapple Gun Powered: Yes";
                grappleCamera.enabled = true;
                firstPersonCam.enabled = false;
                // GrappleSpooger.SetActive = true;

            }
            else
            {
                textGrappleGun.text = "Grapple Gun Powered: No";

                firstPersonCam.enabled = true;
                grappleCamera.enabled = false;
            }
        }
    }


}