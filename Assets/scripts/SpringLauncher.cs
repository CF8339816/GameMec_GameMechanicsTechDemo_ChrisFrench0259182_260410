
using UnityEngine;
using System.Collections;

public class SpringLauncher : MonoBehaviour
{
    public float launchHeight = 300f;
    public float gliderDelay = 25.0f;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController charCtrl = other.GetComponent<CharacterController>();

            if (charCtrl != null)
            { 
                float launchVelocity = Mathf.Sqrt(launchHeight * -6f * -9.8f);

                charCtrl.Move(Vector3.up * launchVelocity * Time.deltaTime);


                GlideControl glider = other.GetComponent<GlideControl>();
                if (glider != null)
                {
                    StartCoroutine(ActivateGlider(glider));
                }
            }
        }
    }

    IEnumerator ActivateGlider(GlideControl glider)
    {
        yield return new WaitForSeconds(gliderDelay);
        glider.StartGliding();


    }

    


}

