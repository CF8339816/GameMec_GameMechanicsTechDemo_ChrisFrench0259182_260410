using UnityEngine.UI;
using UnityEngine;

public class GrappleGunCtrl : MonoBehaviour
{
    [Header("References")]
    public LineRenderer lineRender;
    public Transform barrel; 
    public Transform firstPersonCam;
    public Transform character;
    public playercontroler playerScript;
    public LayerMask Grappleable;

    [Header("Settings")]
    public float maxDistance = 100f;
    public float pullSpeed = 20f;

    [Header("Crosshair Settings")]
    public Image crosshair;
    //public Color normalColor = Color.white;
    //public Color canGrappleColor = Color.green;

    private Vector3 grapplePoint;
    private SpringJoint joint;
    private bool isPulling = false;


    void Start()
    {
        
        if (crosshair != null)
            crosshair.enabled = false;

    
    }
    void Update()
    {
        //    if (playerScript == null || !playerScript.PowerOn)
        //    {
        //        if (crosshair != null) crosshair.enabled = false;
        //        if (isPulling || joint != null) StopGrapple();
        //        return;
        //    }
        UpdateCrosshairVisibility();

        if (Input.GetMouseButtonDown(2)) StartPull();//MiddleMouse
        if (Input.GetMouseButtonUp(2)) StopGrapple();

        if (Input.GetMouseButtonDown(1)) StartSwing();//rightMouse
        if (Input.GetMouseButtonUp(1)) StopGrapple();
    }

    void LateUpdate()
    {
        DrawRope();
        if (isPulling)
        {
           character.position = Vector3.MoveTowards(character.position, grapplePoint, pullSpeed * Time.deltaTime);
        }
    }


    void UpdateCrosshairVisibility()
    {
        //if (crosshair == null ) return;
        if (crosshair == null || !playerScript.PowerOn) return;
        {


            //if (playerScript.PowerOn == true)
            //{

                bool canGrapple = Physics.Raycast(firstPersonCam.position, firstPersonCam.forward, out RaycastHit hit, maxDistance, Grappleable);

                crosshair.enabled = canGrapple;
            //}
        }
    }
    void StartPull()
    {
        if (Physics.Raycast(firstPersonCam.position, firstPersonCam.forward, out RaycastHit hit, maxDistance, Grappleable))
        {
            grapplePoint = hit.point;
            isPulling = true;
            lineRender.positionCount = 2;
        }
    }

    void StartSwing()
    {
        if (Physics.Raycast(firstPersonCam.position, firstPersonCam.forward, out RaycastHit hit, maxDistance, Grappleable))
        {
            grapplePoint = hit.point;
            joint = character.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(character.position, grapplePoint);
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lineRender.positionCount = 2;
        }
    }

    void StopGrapple()
    {
        lineRender.positionCount = 0;
        isPulling = false;
        Destroy(joint);
    }

    void DrawRope()
    {
        if (!joint && !isPulling) return;
        lineRender.SetPosition(0, barrel.position);
        lineRender.SetPosition(1, grapplePoint);
    }
}
