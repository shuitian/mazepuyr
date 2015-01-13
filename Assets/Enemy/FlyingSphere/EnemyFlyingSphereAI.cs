using UnityEngine;
using System.Collections;
using System;

public class EnemyFlyingSphereAI : EnemySphereAI
{
    private float lastDist;
    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
    }

    // Use this for initialization
    protected void Start()
    {
        base.Start();
        attackDistance = 7F;
        moveSpeed = 20F;
        attackTimePerSecond = 1F;
        gameObject.rigidbody.useGravity = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        base.Update();
    }

    void FixedUpdate()
    {
        moveSpeed = 10 + dist / 10;
    }

}
