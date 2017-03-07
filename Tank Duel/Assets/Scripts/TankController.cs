using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    public List<WheelCollider> HoverWheels; 
    public float accelleration;
    public float maxVelocity; 

    private float m_Threshold = 0.1f;
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        foreach (WheelCollider wheel in HoverWheels)
        {

            wheel.motorTorque = Mathf.Epsilon;

        }
    }
    public void FixedUpdate()
    {

        Vector3 forceDirecton = Input.GetAxis("Horizontal") * Camera.main.transform.right + Input.GetAxis("Vertical") * Camera.main.transform.forward;


        //Debug.DrawRay(transform.position, forceDirecton * 1000, new Color(forceDirecton.x, forceDirecton.y, forceDirecton.z));

        

        //Debug.DrawRay(transform.position, forceDirecton * 1000, new Color(forceDirecton.x, forceDirecton.y, forceDirecton.z));

        Move(forceDirecton);




    }

    protected void Move(Vector3 forceDirecton)
    {
        forceDirecton = Vector3.ProjectOnPlane(forceDirecton, transform.up).normalized;

        if (forceDirecton.magnitude > m_Threshold && rb.velocity.magnitude <= maxVelocity)
        {
            rb.AddForce(forceDirecton * accelleration);
        }
    }
}

