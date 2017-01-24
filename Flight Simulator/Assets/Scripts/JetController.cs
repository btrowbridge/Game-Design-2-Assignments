using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetController : MonoBehaviour {

    [Range(50,1000)]
    public float MaxVelocity = 100;
    [Range(1, 100)]
    public float Accelleration = 5;
    [Range(1, 100)]
    public float ViewRange = 50;
    [Range(1, 100)]
    public float RotateSpeed = 10; 

    private Rigidbody rb;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && rb.velocity.magnitude < MaxVelocity)
        {
            rb.AddForce(transform.forward * Accelleration);

        }
        else if (Input.GetKeyDown(KeyCode.S) && rb.velocity.magnitude > 0)
        {
            rb.AddForce(-transform.forward * Accelleration/2);
        }
        var viewPlane = new Plane(-Camera.main.transform.forward, Camera.main.transform.position + Camera.main.transform.forward * ViewRange);

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        var hitdist = 0.0f;

        if (viewPlane.Raycast(ray,out hitdist))
        {
            var targetPoint = ray.GetPoint(hitdist);

            var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotateSpeed * Time.fixedDeltaTime);
        }

    }
}
