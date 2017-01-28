using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class AIAimBarrel : AimBarrel
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate ()
    {
        if (player && (player.transform.position - transform.position).magnitude <= AimDistance)
        {
            AimAt(player.transform.position);
        }
    }
}

