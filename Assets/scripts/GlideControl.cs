using UnityEngine;

public class GlideControl : MonoBehaviour
{
    [Header("Glide Settings")]
    public float glideGravity = -2f;      
    public float glideSpeed = 10f;       
    public float turnSpeed = 100f;        
    public GameObject Glider;
    //private bool isGrounded;
    //private Rigidbody ridgBod;

    private playercontroler PlaCtrl;
    private bool isGliding = false;
    //[SerializeField] Transform groundCheck;
    //[SerializeField] float groundDistance = 0.4f; //grounding variance
    //[SerializeField] LayerMask groundMask;
    //private Vector3 velocity;
    void Awake()
    {
       PlaCtrl = GetComponent<playercontroler>();
        
        //ridgBod = GetComponent<Rigidbody>();
    }

    public void StartGliding()
    {
        isGliding = true;
        if (Glider) Glider.SetActive(true);

        //ridgBod.linearVelocity = new Vector3(ridgBod.linearVelocity.x, 0, ridgBod.linearVelocity.z);
    }

    void FixedUpdate()
    {
        if (!isGliding)
        {
            
            //Vector3 velocitty = ridgBod.linearVelocity; 
            //if (velocitty.y < glideGravity)
            //{
            //    ridgBod.linearVelocity = new Vector3(velocitty.x, glideGravity, velocitty.z);
            //}

           
            float rotation = Input.GetAxis("Horizontal") * turnSpeed * Time.fixedDeltaTime;
            transform.Rotate(0, rotation, 0);
            //ridgBod.MoveRotation(ridgBod.rotation * Quaternion.Euler(0, rotation, 0));
            PlaCtrl.SetVerticalVelocity(glideGravity);
            //ridgBod.MovePosition(transform.position + transform.forward * glideSpeed * Time.fixedDeltaTime);

            Vector3 forwardMove = transform.forward * glideSpeed;

            //ridgBod.linearVelocity = new Vector3(forwardMove.x, ridgBod.linearVelocity.y, forwardMove.z);

            if (PlaCtrl.isGrounded)
            {
                StopGliding();
            }
            //CheckLanding();
        }
    }

    //void CheckLanding()
    //{
    //    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //grounded check
    //    //if (isGrounded && velocity.y < 0)
    //    //{
    //    //    velocity.y = -15f; // small downward force to keep grounded
    //    //}
    //    //else
    //    //{
    //    //    isGrounded = false;
    //    //}


    //    if (isGrounded && ridgBod.linearVelocity.y <= 0.1f)
    //    // if (Physics.Raycast(transform.position, Vector3.down, 0.5f))
    //    {
    //        StopGliding();
    //    }
    //}

    public void StopGliding()
    {
        isGliding = false;
        if (Glider) Glider.SetActive(false);
    }
}
