using UnityEngine;
using TMPro; 

public class GrappleStatus : MonoBehaviour
{
    public playercontroler playerScript; 
    public TMPro.TextMeshProUGUI textGrappleGun;

    void Update()
    {
        SetTextGrappleGun();
    }

    void SetTextGrappleGun()
    {
       
        if (playerScript != null)
        {
            if (playerScript.PowerOn == true)
            {
                textGrappleGun.text = "Grapple Gun Powered: Yes";
            }
            else
            {
                textGrappleGun.text = "Grapple Gun Powered: No";
            }
        }
    }


}