using UnityEngine;
using System.Collections;
using System;

public class EnemyFlyingSphereAI : EnemySphereAI
{
    private float lastDist;
	// Use this for initialization
	void Start () {
        m_SelfTransform = transform;
        attackDistance = 7F;
        moveSpeed = 10F;
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
