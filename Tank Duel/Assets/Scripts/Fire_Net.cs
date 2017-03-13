using UnityEngine;
using UnityEngine.Networking;

public class Fire_Net : NetworkBehaviour
{
    public GameObject Ammo;

    public Transform AmmoSpawnPoint;
    //public AudioClip Audio;

    [Range(0, 1)]
    public float FireRate;

    [Range(2, 1000.0f)]
    public float FireForce;

    protected float nextShot = 0.0F;

    // Update is called once per frame
    private void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextShot)
            {
                //Debug.Log("Time: " + Time.time + ", nextDig: " + nextDig);
                nextShot = Time.time + FireRate;
                CmdShoot();
            }
        }

    }

    [Command]
    protected void CmdShoot()
    {
        var bullet = GameObject.Instantiate(Ammo, AmmoSpawnPoint.position, transform.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(AmmoSpawnPoint.up * FireForce);

        NetworkServer.Spawn(bullet);
    }
}