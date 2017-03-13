using UnityEngine;
using UnityEngine.Networking;

public class TankHealth_Net : NetworkBehaviour
{
    public int health = 20;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        if (!isServer || health <= 0 ) return;

        health -= damage;
        if (health <= 0)
        {
            RpcDied();
        }
    }

    [ClientRpc]
    private void RpcDied()
    {
        Network.Destroy(gameObject);
    }
}