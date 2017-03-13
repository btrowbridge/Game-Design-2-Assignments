using UnityEngine;
using UnityEngine.Networking;

public class TankController_Net : NetworkBehaviour
{
    public float accelleration;
    public float maxVelocity;

    private float m_Threshold = 0.1f;
    private Rigidbody rb;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }
        rb = GetComponent<Rigidbody>();
        
    }

    public void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            Vector3 forceDirecton = Input.GetAxis("Horizontal") * Camera.main.transform.right + Input.GetAxis("Vertical") * Camera.main.transform.forward;
            //Debug.DrawRay(transform.position, forceDirecton * 1000, new Color(forceDirecton.x, forceDirecton.y, forceDirecton.z));

            CmdMove(forceDirecton);
        }
    }

    
    public void CmdMove(Vector3 forceDirecton)
    {
        forceDirecton = Vector3.ProjectOnPlane(forceDirecton, transform.up).normalized;

        if (forceDirecton.magnitude > m_Threshold && rb.velocity.magnitude <= maxVelocity)
        {
            rb.AddForce(forceDirecton * accelleration);
        }
        
    }
}