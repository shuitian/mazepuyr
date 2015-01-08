using UnityEngine;
using System.Collections;
using System;

public class EnemyBaseAI : MonoBehaviour {

    public float attackDistance = 1F;
    public float moveSpeed = 1F;
    public float attackTimePerSecond = 1F;
    protected float nextAttackTimeLeft = 0F;
    protected bool canAttack = false;
    protected Transform m_SelfTransform;

    public Vector3 enemyPosition;
    protected  float dist;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	protected void Update () {
        setCanvasTransform();
        checkAttack();
        doAction();
	}

    protected virtual void setCanvasTransform()
    {
        try
        {
            enemyPosition = PlayerBaseStatement.player.transform.position;
        }
        catch (Exception e)
        {
            enemyPosition = transform.position;
        }
        transform.parent.Find("EnemyStatementCanvas").LookAt(enemyPosition, Vector3.up);
    }

    protected virtual void checkAttack()
    {
        if (!canAttack)
        {
            nextAttackTimeLeft -= Time.deltaTime;
        }
        if (nextAttackTimeLeft <= 0)
        {
            nextAttackTimeLeft = 1 / attackTimePerSecond;
            canAttack = true;
        }
    }
    protected virtual void doAction()
    {
        dist = Vector3.Distance(m_SelfTransform.position, enemyPosition);

        if (dist <= attackDistance)
        {
            attack();
        }
        else
        {
            move(enemyPosition);
        }
    }
    

    protected virtual void attack()
    {

    }

    protected virtual void move(Vector3 enemyPosition)
    {
        m_SelfTransform.position = m_SelfTransform.position + (enemyPosition - m_SelfTransform.position).normalized * moveSpeed * Time.deltaTime; ;
    }
}
