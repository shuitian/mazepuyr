using UnityEngine;
using System.Collections;
using System;

public class SphereEnemyAI : EnemyBaseAI
{
    //Vector3 lastPosition;
    //Vector3 newPosition;
    float lastDist;
	// Use this for initialization
	void Start () {
        m_SelfTransform = transform;
        attackDistance = 10F;
        moveSpeed = 5F;
        attackTimePerSecond = 1F;
        //lastPosition = Vector3.zero;
        lastDist = 0F;
	}

    //void FixedUpdate()
    //{
    //    rigidbody.AddForce(0, 10, 0);
    //}

	// Update is called once per frame
	protected void Update () {
        Vector3 position1;
        try
        {
            position1 = PlayerBaseStatement.player.transform.position;
        }
        catch (Exception e)
        {
            position1 = Vector3.zero;
        }
        float dist = Vector3.Distance(m_SelfTransform.position, position1);
        if (!canAttack)
        {
            nextAttackTimeLeft -= Time.deltaTime;
        }
        if (nextAttackTimeLeft <= 0)
        {
            nextAttackTimeLeft = 1/attackTimePerSecond;
            canAttack = true;
        }
        transform.parent.Find("Canvas").LookAt(position1, Vector3.up);
        if (dist <= attackDistance)
        {
            attack();
        }
        else
        {
            move(position1);
        }


        //if (dist >= lastDist)
        //{
        //    moveSpeed += 2;
        //}
        //else
        //{
        //    if (moveSpeed > 5)
        //    {
        //        moveSpeed--;
        //    }
        //}
        //lastDist = dist;
	}

    protected override void attack()
    {
        if (PlayerBaseStatement.playerBaseStatement == null)
        {
            return;
        }
        if (canAttack)
        {
            EnemyBaseStatement state = GetComponent<EnemyBaseStatement>();
            if (state == null)
            {
                return;
            }
            try
            {
                PlayerBaseStatement.playerBaseStatement.loseHp(state.attack - PlayerStatement.baseDefensePerLevel[PlayerBaseStatement.playerBaseStatement.level]);
            }
            catch (IndexOutOfRangeException e)
            {
                PlayerBaseStatement.playerBaseStatement.loseHp(state.attack - PlayerStatement.baseDefensePerLevel[0]);
            }
            canAttack = false;
        }
    }

    protected override void move(Vector3 position1)
    {
        //Vector3 p1 = (position1 - m_SelfTransform.position).normalized;
        //rigidbody.AddForce(p1.x, p1.y, p1.z);
        Vector3 p = m_SelfTransform.position + (position1 - m_SelfTransform.position).normalized * moveSpeed * Time.deltaTime;

        //float y = MyTerrainData.terrainData.GetHeight((Int32)p.x, (Int32)p.z) + gameObject.transform.lossyScale.y;
        //if (p.y <= y)
        //{
        //    p.y = y;
        //}
        m_SelfTransform.position = p;
        //float d = Vector3.Distance(m_SelfTransform.position, lastPosition);
        //if (d < 0.5)
        //{
        //    moveSpeed++;
        //}
        //else
        //{
        //    if (moveSpeed > 5)
        //    {
        //        moveSpeed--;
        //    }
        //}
        //lastPosition = m_SelfTransform.position;
    }
}
