using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TankHealth_Net : NetworkBehaviour {


    public int health = 20;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            RpcDied();
        }
    }

    [ClientRpc]
    void RpcDied()
    {
        Network.Destroy(gameObject);
    }
}
