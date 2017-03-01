using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour {


    Rigidbody rb;

	// Use this for initialization
	void Start () {
        if (isServer)
        {
            rb = GetComponent<Rigidbody>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (isClient)
        {
            //Client
        }
        if (isServer)
        {
            //Server
        }
        if (isLocalPlayer)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Cmd_Move(h, v);
        }
	}

    [Command]
    void Cmd_Move(float x, float z)
    {
        rb.velocity = new Vector3(x, 0, z);
    }
}
