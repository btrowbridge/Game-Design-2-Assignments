using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public GameObject Player;
    public Transform SpawnPoint;
    public void SpawnPalyer(GameObject newPlayer)
    {
        if (Player) Destroy(Player);

        Player = newPlayer;
        Instantiate(Player, SpawnPoint.position, Quaternion.identity);
    }
}
