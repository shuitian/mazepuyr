using UnityEngine;
using System.Collections;

public class SkillAttack : MonoBehaviour {

    public GameObject toBeAttacked;
    public GameObject attacker;

    public BaseStatement toBeAttackedStatement;
    public BaseStatement attackerStatement;

    public int checkDistFrames = 10;
    public float attackDistance = 10;
    public float attackTimePerSecond = 1;

    protected bool inAttackDistance;
    protected float lastAttackTime = 0;
    int i;

    void OnEnable()
    {
        toBeAttacked = PlayerBaseStatement.player;
        toBeAttackedStatement = PlayerBaseStatement.playerBaseStatement;
        i = 0;
    }

    void FixedUpdate()
    {
        if (!toBeAttacked || !toBeAttackedStatement) 
        {
            return;
        }
        if (i++ > checkDistFrames)
        {
            i = 0;
            float dist = Vector3.Distance(toBeAttacked.transform.position, attacker.transform.position);
            if (dist < attackDistance)
            {
                inAttackDistance = true;
            }
            else
            {
                inAttackDistance = false;
            }
        }
    }

	// Update is called once per frame
    void Update()
    {
        if (inAttackDistance)
        {
            if (Time.time - lastAttackTime > 1 / attackTimePerSecond)
            {
                attack();
                lastAttackTime = Time.time;
            }
        }
	}

    public virtual void attack()
    {
        toBeAttackedStatement.loseHp(attackerStatement, attackerStatement.baseAttackPerLevel[attackerStatement.level] * (1 - toBeAttackedStatement.baseDefensePerLevel[toBeAttackedStatement.level]));
    }

    public void setToBeAttacked(GameObject toBeAttacked)
    {
        this.toBeAttacked = toBeAttacked;
        toBeAttackedStatement = toBeAttacked.GetComponent<BaseStatement>();
    }
}
