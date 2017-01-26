using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    public List<AxleInfo> axleInfos; 
    public float accelleration;
    public float maxVelocity; 

    private float m_Threshold = 0.1f;
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        foreach (AxleInfo axleInfo in axleInfos)
        {

            axleInfo.leftWheel.motorTorque = Mathf.Epsilon;
            axleInfo.rightWheel.motorTorque = Mathf.Epsilon;

        }
    }
    public void FixedUpdate()
    {
        
        Vector3 force = Input.GetAxis("Horizontal") * Camera.main.transform.right + Input.GetAxis("Vertical") * Camera.main.transform.forward;
        Debug.Log(force.magnitude);

        Debug.DrawRay(transform.position, force * 1000, new Color(force.x,force.y,force.z));

        force = Vector3.ProjectOnPlane(force, transform.up);

        Debug.DrawRay(transform.position, force * 1000, new Color(force.x, force.y, force.z));
        
        if(force.magnitude > m_Threshold && rb.velocity.magnitude <= maxVelocity)
        {
            Debug.Log(force.magnitude);
            rb.AddForce(force * accelleration);
        }


    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
