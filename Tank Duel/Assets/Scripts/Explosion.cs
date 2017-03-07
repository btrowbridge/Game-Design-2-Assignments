using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public int explosionDamage = 1;
    public float explosionDuration = 2;
    public float explosiveForce = 1000;
    void Awake()
    {
        Destroy(gameObject, explosionDuration);
    }

    void OnTriggerEnter(Collider other)
    {
        var go = other.gameObject;

        if (other.tag == "Player" || other.tag == "Enemy")
        {
            TankHealth tankHealth = other.GetComponent<TankHealth>();
            if(tankHealth != null) tankHealth.TakeDamage(explosionDamage);

            Vector3 appliedForce = (go.transform.position - transform.position) * explosiveForce;

            var oRB = other.GetComponentInParent<Rigidbody>();
            if (oRB != null) oRB.AddForce(appliedForce);
            
        }
    }

}
