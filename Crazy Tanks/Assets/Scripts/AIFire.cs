using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFire : Fire {

    [Range(50, 1000)]
    public float FireAtPlayerRange = 1000;
    [Range(0, 50)]
    public float FireAtPlayerAngle = 10;

    private Transform player;
    private Vector3 playerDir;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        playerDir = player.position - transform.position;
            if (Time.time >= nextShot && 
            Physics.Raycast (transform.position, playerDir, FireAtPlayerRange) && 
            Vector3.Dot(playerDir.normalized, AmmoSpawnPoint.up.normalized) <= FireAtPlayerAngle)
            {
                //Debug.Log("Time: " + Time.time + ", nextDig: " + nextDig);
                nextShot = Time.time + FireRate;
                Shoot();
            }
            
        
    }
}
