
using UnityEngine;
using System.Collections;

public class SpringLauncher : MonoBehaviour
{
    public float launchForce = 180f;
    public float gliderDelay = 0.5f;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody ridgieB = other.GetComponent<Rigidbody>();
           

            if (ridgieB != null)
            {
                ridgieB.linearVelocity = new Vector3(ridgieB.linearVelocity.x, 0, ridgieB.linearVelocity.z);


                ridgieB.AddForce(Vector3.up * launchForce, ForceMode.Impulse);

               
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

        //isGliding = true;
        
        //if (isGliding = true)
        //{
        //    Glider.SetActive(true);
        //}
        //else 
        //{
        //    Glider.SetActive(true); 
        //}
    }

    


}

