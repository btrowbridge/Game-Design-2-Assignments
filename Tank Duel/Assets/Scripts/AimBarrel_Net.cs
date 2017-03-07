using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class AimBarrel_Net : NetworkBehaviour {

    public float RotateSpeed = 10;
    public float AimDistance = 1000;

    public GameObject pivot;
	// Use this for initialization
	void Start () {
        if (!isLocalPlayer) Destroy(this);
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));

        Debug.DrawRay(ray.origin, ray.direction * AimDistance, Color.yellow);
        Debug.DrawRay(transform.position, transform.forward * AimDistance, Color.blue);

        //RaycastHit hit;
        Vector3 targetPoint = ray.GetPoint(AimDistance);

        AimAt(targetPoint);


    }

    protected void AimAt(Vector3 targetPoint)
    {
        var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

      pivot.transform.rotation = Quaternion.Slerp(pivot.transform.rotation, targetRotation, RotateSpeed * Time.fixedDeltaTime);

    }
}
