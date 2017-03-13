using UnityEngine;

public class Explode : MonoBehaviour
{
    public int collisionDamage = 5;
    public GameObject explosion;
    // Use this for initialization

    private float invulnerabilityTime = 0.2f;

    private void Start()
    {
        invulnerabilityTime += Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Time.time < invulnerabilityTime) return;

        var other = collision.gameObject;

        if (other.tag == "Player" || other.tag == "Enemy")
        {
            TankHealth_Net tankHealth = other.GetComponent<TankHealth_Net>();
            if(tankHealth)
                tankHealth.TakeDamage(collisionDamage);
        }
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        if (!this.enabled)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}