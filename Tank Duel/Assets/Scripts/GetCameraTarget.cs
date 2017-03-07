using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Cameras;

public class GetCameraTarget : NetworkBehaviour {

    public GameObject CameraTarget;
	// Use this for initialization
	void Start () {
		if (isLocalPlayer)
        {
            var CameraRig = FindObjectOfType<FreeLookCam>();
            CameraRig.SetTarget(CameraTarget.transform);
        }
	}
	

}
