using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public GameObject Ammo;
    public Transform AmmoSpawnPoint;

    [Range(0, 1)]
    public float FireRate;
    [Range(2, 250)]
    public float FireForce;


    private float nextShot = 0.0F;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextShot)
        {
            //Debug.Log("Time: " + Time.time + ", nextDig: " + nextDig);
            nextShot = Time.time + FireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        var bullet = GameObject.Instantiate(Ammo, AmmoSpawnPoint.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * FireForce, ForceMode.Impulse);
    }
}
