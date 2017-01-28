using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    
    public float hoverDistance = 0.75f;
    public float hoverForce = 10.0f;
    public float jumpForce = 1000.0f;
    public List<Transform> boosters;
    private float currentHeight = 0.0f;
    private float hoverForceMultiplier = 0.0f;
    private Vector3 hoverForceApplied = Vector3.zero;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }
    void FixedUpdate()
    {
        ActivateBoosters();
    }

    private void ActivateBoosters()
    {
        foreach (var booster in boosters)
        {
            // -- find hover distance and add force to make hover   
            RaycastHit rayHit;
            if (Physics.Raycast(booster.position, Vector3.down, out rayHit))
            {
                if (rayHit.collider.CompareTag("Environment"))
                {
                    currentHeight = rayHit.distance;
                    float boostedForce = 0;
                    if (Input.GetKeyDown(KeyCode.Space) && tag == "Player")
                    {
                        boostedForce = jumpForce;
                    }

                    if (currentHeight < (hoverDistance - Time.fixedDeltaTime))
                    {
                        // find percentage of currentHeight below hoverDistance

                        hoverForceMultiplier = (hoverDistance - currentHeight) / hoverDistance;
                        hoverForceApplied = (Vector3.up * hoverForce * hoverForceMultiplier) + (Vector3.up * 9.8f) + (boostedForce * Vector3.up);
                        rb.AddForceAtPosition(hoverForceApplied, booster.position);
                    }
                    else
                    {
                        // apply anti-gravity force for half distance above hoverDistance
                        if ((currentHeight - hoverDistance - Time.fixedDeltaTime) < (hoverDistance / 2))
                        {
                            hoverForceApplied = (Vector3.up * 9.8f) * ((hoverDistance - (currentHeight - hoverDistance)) / hoverDistance) + (boostedForce * Vector3.up);
                            rb.AddForceAtPosition(hoverForceApplied, booster.position);
                        }
                    }

                }
                else //find balance
                {
                    rb.angularVelocity = Vector3.zero;
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.fixedDeltaTime);
                    
                }
            }

        }
    }
}

