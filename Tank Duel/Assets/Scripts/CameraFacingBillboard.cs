using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour {

    Camera cameraTarget;
	// Use this for initialization
	void Start () {
        cameraTarget = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 v = cameraTarget.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(cameraTarget.transform.position - v);
        transform.Rotate(0, 180, 0);
        
    }
}
