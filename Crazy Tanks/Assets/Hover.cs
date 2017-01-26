using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public GameObject Body;
    public float hoverDistance = 0.75f;
    public float hoverForce = 10.0f;
    private float currentHeight = 0.0f;
    private float hoverForceMultiplier = 0.0f;
    private Vector3 hoverForceApplied = Vector3.zero;
    private Rigidbody rb;

    void Start()
    {
        rb = Body.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        // -- find hover distance and add force to make hover   
        RaycastHit rayHit;
        if(Physics.Raycast(transform.position, Vector3.down, out rayHit)) {
            if (rayHit.collider.CompareTag("Environment"))
            {
                currentHeight = rayHit.distance;
                if (currentHeight < (hoverDistance - Time.deltaTime))
                {
                    // find percentage of currentHeight below hoverDistance
                    hoverForceMultiplier = (hoverDistance - currentHeight) / hoverDistance;
                    hoverForceApplied = (Vector3.up * hoverForce * hoverForceMultiplier) + (Vector3.up * 9.8f);
                    rb.AddForceAtPosition(hoverForceApplied, transform.position);
                }
                else
                {
                    // apply anti-gravity force for half distance above hoverDistance
                    if ((currentHeight - hoverDistance - Time.deltaTime) < (hoverDistance / 2))
                    {
                        hoverForceApplied = (Vector3.up * 9.8f) * ((hoverDistance - (currentHeight - hoverDistance)) / hoverDistance);
                    }
                }
            }
        }
    }
}

