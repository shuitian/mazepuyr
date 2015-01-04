using UnityEngine;
using System.Collections;
using System;

public class CubeEnemyAI : EnemyBaseAI
{

	// Use this for initialization
	void Start () {
        m_SelfTransform = transform;
        attackDistance = 15F;
        moveSpeed = 10F;
        attackTimePerSecond = 2F;
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
            nextAttackTimeLeft = 1 / attackTimePerSecond;
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
        m_SelfTransform.position += (position1 - m_SelfTransform.position).normalized * moveSpeed * Time.deltaTime;
    }
}
