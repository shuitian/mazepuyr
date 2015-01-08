using UnityEngine;
using System.Collections;
using System;

public class EnemyCubeAI : EnemyBaseAI
{

	// Use this for initialization
	void Start () {
        m_SelfTransform = transform;
        attackDistance = 25F;
        moveSpeed = 10F;
        attackTimePerSecond = 2F;
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
                print(e);
                PlayerBaseStatement.playerBaseStatement.loseHp(GetComponent<EnemyBaseStatement>(), state.baseAttackPerLevel[state.level] - PlayerBaseStatement.playerBaseStatement.baseDefensePerLevel[0]);
            }
            canAttack = false;
        }
    }
}
