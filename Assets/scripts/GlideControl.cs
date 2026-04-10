using UnityEngine;

public class GlideControl : MonoBehaviour
{
    [Header("Glide Settings")]
    public float glideGravity = -2f;      
    public float glideSpeed = 10f;       
    public float turnSpeed = 100f;        
    public GameObject Glider;
   
    [SerializeField] float landDistance = 0.6f; 
    [SerializeField] string groundTag = "ground";

    private playercontroler PlaCtrl;
    private bool isGliding = false;
  
    void Awake()
    {
       PlaCtrl = GetComponent<playercontroler>();
        
    }

    public void StartGliding()
    {
        isGliding = true;
        if (Glider) Glider.SetActive(true);

        
    }

    void FixedUpdate()
    {
        if (isGliding)
        {
            float rotation = Input.GetAxis("Horizontal") * turnSpeed * Time.fixedDeltaTime;
            transform.Rotate(0, rotation, 0);
           
            PlaCtrl.SetVerticalVelocity(glideGravity);

            //Vector3 forwardMove = transform.forward * glideSpeed;
            Vector3 forwardMove = transform.forward * glideSpeed * Time.fixedDeltaTime;
            PlaCtrl.characterController.Move(forwardMove);
           
            //if (PlaCtrl.isGrounded)
            //{
            //    StopGliding();
            //}
           CheckLanding();
        }
    }

    void CheckLanding()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, landDistance))
        {           
            if (hit.collider.CompareTag(groundTag))
            {
                StopGliding();
            }
        }

        if (PlaCtrl.characterController.isGrounded)
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
