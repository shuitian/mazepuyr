using UnityEngine;
using System.Collections;
using System;

public class FlyingSphereAI : SphereEnemyAI
{
	// Use this for initialization
	void Start () {
        m_SelfTransform = transform;
        attackDistance = 5F;
        moveSpeed = 5F;
        attackTimePerSecond = 1F;
        gameObject.rigidbody.useGravity = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        base.Update();
    }

    protected override void move(Vector3 position1)
    {
        if (MyTerrainData.terrainData.GetHeight((Int32)m_SelfTransform.position.x, (Int32)m_SelfTransform.position.z) < m_SelfTransform.position.y )
        {
            Vector3 direct = position1 - m_SelfTransform.position;
            direct = new Vector3(direct.x, direct.y * 3, direct.z);
            m_SelfTransform.position += direct.normalized * moveSpeed * Time.deltaTime;
        }
        else
        {
            m_SelfTransform.position += (position1 - m_SelfTransform.position).normalized * moveSpeed * Time.deltaTime;
        }
    }
}
