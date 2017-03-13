using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int explosionDamage = 1;
    public float explosionDuration = 2;
    public float explosiveForce = 1000;

    private void Awake()
    {
        Destroy(gameObject, explosionDuration);
    }

    private void OnTriggerEnter(Collider other)
    {
        var go = other.gameObject;

        if (other.tag == "Player" || other.tag == "Enemy")
        {
            TankHealth_Net tankHealth = other.GetComponent<TankHealth_Net>();
            if (tankHealth != null) tankHealth.TakeDamage(explosionDamage);

            Vector3 appliedForce = (go.transform.position - transform.position) * explosiveForce;

            var oRB = other.GetComponentInParent<Rigidbody>();
            if (oRB != null) oRB.AddForce(appliedForce);
        }
    }
}