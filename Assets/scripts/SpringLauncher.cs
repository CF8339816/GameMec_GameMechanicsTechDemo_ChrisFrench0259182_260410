
using UnityEngine;
using System.Collections;

public class SpringLauncher : MonoBehaviour
{
    public float launchForce = 20f;
    public float gliderDelay = 0.5f;
    //public bool isGliding = false;
    //public GameObject Glider;
    private Vector3 velocity;
    [SerializeField] float gravity = -9.8f; //has to be neg because is downward force
    [SerializeField] float jumpHeight = 2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            GlideControl glider = other.GetComponent<GlideControl>();

            if (rb != null)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -15f * gravity);
                //rb.linearVelocity = Vector3.zero;

                //rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);


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

