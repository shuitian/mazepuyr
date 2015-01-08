using UnityEngine;
using System.Collections;
using System;

public class EnemySphereAI : EnemyBaseAI
{
	// Use this for initialization
	void Start () {
        m_SelfTransform = transform;
        attackDistance = 20F;
        moveSpeed = 5F;
        attackTimePerSecond = 1F;
	}

	// Update is called once per frame
	protected void Update () {
        base.Update();
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
                PlayerBaseStatement.playerBaseStatement.loseHp(GetComponent<EnemyBaseStatement>(), state.baseAttackPerLevel[state.level] - PlayerBaseStatement.playerBaseStatement.baseDefensePerLevel[PlayerBaseStatement.playerBaseStatement.level]);
            }
            catch (IndexOutOfRangeException e)
            {
                PlayerBaseStatement.playerBaseStatement.loseHp(GetComponent<EnemyBaseStatement>(), state.baseAttackPerLevel[state.level] - PlayerBaseStatement.playerBaseStatement.baseDefensePerLevel[0]);
            }
            canAttack = false;
        }
    }

    
}
