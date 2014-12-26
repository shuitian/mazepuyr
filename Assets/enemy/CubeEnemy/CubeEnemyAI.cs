using UnityEngine;
using System.Collections;

public class CubeEnemyAI : EnemyBaseAI
{

	// Use this for initialization
	void Start () {
        m_TargetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        m_SelfTransform = transform;
        attackDistance = 15F;
        moveSpeed = 10F;
        attackTimePerSecond = 2F;
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(m_SelfTransform.position, m_TargetTransform.position);
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
            m_SelfTransform.position += (m_TargetTransform.position - m_SelfTransform.position).normalized * moveSpeed * Time.deltaTime;
        }
	}

    protected override void attack()
    {
        if (canAttack)
        {
            EnemyBaseStatement state = GetComponent<EnemyBaseStatement>();
            PlayerBaseStatement.playerBaseStatement.loseHp(state.attack - PlayerStatement.baseDefensePerLevel[PlayerBaseStatement.playerBaseStatement.level]);
            canAttack = false;
        }
    }
}
