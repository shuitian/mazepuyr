using UnityEngine;
using System.Collections;
using System;

public class EnemyYellowSphereAI : EnemySphereAI
{
    GameObject bulletStoneSpear;
	// Use this for initialization
	void Start () {
        m_SelfTransform = transform;
        attackDistance = 200F;
        moveSpeed = 5F;
        attackTimePerSecond = 0.3F;
        bulletStoneSpear = Resources.Load("Prefab/Arms/BulletStoneSpear") as GameObject;
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
                Vector3 p = (enemyPosition - m_SelfTransform.position).normalized;
                GameObject clone = Instantiate(bulletStoneSpear, transform.position, transform.rotation) as GameObject;
                BulletBaseParameter bulletBaseParameter = clone.GetComponent<BulletBaseParameter>();
                bulletBaseParameter.setDamage(clone.GetComponent<BulletBaseParameter>().getBaseDamage() + state.baseAttackPerLevel[state.level]);
                bulletBaseParameter.damager = state;
                clone.tag = tag;

                clone.transform.parent = GameObject.FindGameObjectWithTag("BulletGroup").transform;
                clone.rigidbody.velocity = p * clone.GetComponent<BulletBaseParameter>().getSpeed();
                clone.transform.rotation = Quaternion.FromToRotation(Vector3.forward, p);
            }
            catch (IndexOutOfRangeException e)
            {
                PlayerBaseStatement.playerBaseStatement.loseHp(GetComponent<EnemyBaseStatement>(), state.baseAttackPerLevel[state.level] - PlayerBaseStatement.playerBaseStatement.baseDefensePerLevel[0]);
            }
            canAttack = false;
        }
    }

    
}
