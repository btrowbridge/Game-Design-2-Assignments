
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class AIController : TankController 
{
    [Range(0, 10)]
    public float RandomizeRate = 10.0f;
    [Range(0, 1)]
    public float followPlayerVarience = 0.2f;
    [Range(50, 1000)]
    public float followRange = 100;

    private Vector3 mMoveDireciton;
    private float mNextTurn = 0;
    private Transform player;
    private Vector3 playerDirection;
    void Start()
    {
        mMoveDireciton = transform.forward * accelleration;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerDirection = player.position - transform.position;
    }
    void Update()
    {
        if (player && Time.time >= mNextTurn)
        {
            mNextTurn = Time.time + RandomizeRate;
            RandomizeDirection();
        }
    }

    new void FixedUpdate()
    {
        playerDirection = player.position - transform.position;
        if (Physics.Raycast(transform.position,playerDirection, followRange))
            Move(mMoveDireciton);
    }

    private void RandomizeDirection()
    {
        float x = Random.Range(-followPlayerVarience, followPlayerVarience);
        float y = 0.0f;
        float z = Random.Range(-followPlayerVarience, followPlayerVarience);

        var randomOffset = new Vector3(x, y, z).normalized;
        mMoveDireciton = playerDirection.normalized + randomOffset;

    }

    
}

