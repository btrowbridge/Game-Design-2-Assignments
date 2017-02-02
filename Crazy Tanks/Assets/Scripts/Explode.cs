using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    public int collisionDamage = 5;
    public GameObject explosion;
    // Use this for initialization

    private float invulnerabilityTime = 0.2f;
	void Start () {
        invulnerabilityTime += Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision collision)
    {
        if (Time.time < invulnerabilityTime) return;

        var other = collision.gameObject;

        if (other.tag == "Player" || other.tag == "Enemy")
        {
            TankHealth tankHealth = other.GetComponent<TankHealth>();
            tankHealth.TakeDamage(collisionDamage);
        }
        Destroy(gameObject);
    }

    void OnDisable()
    {
        if (!this.enabled)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
