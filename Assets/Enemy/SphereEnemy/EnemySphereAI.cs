using UnityEngine;
using System.Collections;
using System;

public class EnemySphereAI : EnemyBaseAI
{
    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
    }

    // Use this for initialization
    protected void Start()
    {
        base.Start();
        attackDistance = 20F;
        moveSpeed = 10F;
        attackTimePerSecond = 1F;
	}

	// Update is called once per frame
	protected void Update () {
        base.Update();
	}

    protected override void attack(GameObject enemy)
    {
        base.attack(enemy);
        BaseStatement enemyStatement = enemy.GetComponent<BaseStatement>();
        if (enemy == null || baseStatement == null || enemyStatement == null) 
        {
            return;
        }
        if (canAttack)
        {
            enemyStatement.loseHp(baseStatement, baseStatement.baseAttackPerLevel[baseStatement.level] - enemyStatement.baseDefensePerLevel[enemyStatement.level]);
            canAttack = false;
        }
    }
}
