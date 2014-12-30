using UnityEngine;
using System.Collections;
using System;

public class SphereEnemyAI : EnemyBaseAI
{
	// Use this for initialization
	void Start () {
        m_SelfTransform = transform;
        attackDistance = 10F;
        moveSpeed = 5F;
        attackTimePerSecond = 1F;
	}
	
	// Update is called once per frame
	void Update () {
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
        if (dist <= attackDistance)
        {
            attack();
        }
        else
        {
            //var lookRotation = Quaternion.LookRotation(position1 - m_SelfTransform.position);
            //m_SelfTransform.rotation = Quaternion.Slerp(m_SelfTransform.rotation, lookRotation, 1000*Time.deltaTime);
            m_SelfTransform.position += (position1 - m_SelfTransform.position).normalized * moveSpeed * Time.deltaTime;
        }
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
}
