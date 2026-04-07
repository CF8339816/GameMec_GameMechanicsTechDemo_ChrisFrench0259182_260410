using UnityEngine;

public class GlideControl : MonoBehaviour
{
    [Header("Glide Settings")]
    public float glideGravity = -2f;      
    public float glideSpeed = 10f;       
    public float turnSpeed = 50f;        
    public GameObject Glider;
    private bool isGrounded;
    private Rigidbody rb;
    private bool isGliding = false;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.2f; //grounding variance
    [SerializeField] LayerMask groundMask;
    private Vector3 velocity;
    void Awake() => rb = GetComponent<Rigidbody>();

    public void StartGliding()
    {
        isGliding = true;
        if (Glider) Glider.SetActive(true);
    }

    void FixedUpdate()
    {
        if (isGliding)
        {
            
            Vector3 velocitty = rb.linearVelocity; 
            if (velocitty.y < glideGravity)
            {
                rb.linearVelocity = new Vector3(velocitty.x, glideGravity, velocitty.z);
            }

           
            float rotation = Input.GetAxis("Horizontal") * turnSpeed * Time.fixedDeltaTime;
            transform.Rotate(0, rotation, 0);

          
            rb.MovePosition(transform.position + transform.forward * glideSpeed * Time.fixedDeltaTime);

          
            CheckLanding();
        }
    }

    void CheckLanding()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //grounded check
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -15f; // small downward force to keep grounded
        }
        else
        {
            isGrounded = false;
        }



        if (Physics.Raycast(transform.position, Vector3.down, 0.5f))
        {
            StopGliding();
        }
    }

    public void StopGliding()
    {
        isGliding = false;
        if (Glider) Glider.SetActive(false);
    }
}
