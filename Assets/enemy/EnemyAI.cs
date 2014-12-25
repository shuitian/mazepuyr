using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    public float moveSpeed = 5;
    public float attackTimePerSecond = 1F;
    private float nextAttackTimeLeft = 1F;
    private bool canAttack = false;
    private Transform m_TargetTransform;
    private Transform m_SelfTransform;

	// Use this for initialization
	void Start () {
        moveSpeed = 5;
        attackTimePerSecond = 1F;
        nextAttackTimeLeft = 1F;
        var player = GameObject.FindGameObjectWithTag("Player");
        m_TargetTransform = player.transform;
        m_SelfTransform = transform;
        nextAttackTimeLeft = attackTimePerSecond;
	}
	
	// Update is called once per frame
	void Update () {
        var dist = Vector3.Distance(m_SelfTransform.position, m_TargetTransform.position);
        if (!canAttack)
        {
            nextAttackTimeLeft -= Time.deltaTime;
        }
        if (nextAttackTimeLeft <= 0)
        {
            nextAttackTimeLeft = 1/attackTimePerSecond;
            canAttack = true;
        }
        if (dist <= 10)
        {
            attack();
        }
        else
        {
            m_SelfTransform.position += (m_TargetTransform.position - m_SelfTransform.position).normalized * moveSpeed * Time.deltaTime;
        }
	}

    void attack()
    {
        if (canAttack)
        {
            EnemyStatement state = GetComponent<EnemyStatement>();
            PlayerStatement.playerStatement.loseHp(state.attack - PlayerStatement.baseDefensePerLevel[PlayerStatement.playerStatement.level]);
            canAttack = false;
        }
    }
}
