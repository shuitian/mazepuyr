using UnityEngine;
using System.Collections;
using System;

public class EnemyBaseAI : MonoBehaviour {

    public float attackDistance = 1F;
    public float moveSpeed = 1F;
    public float attackTimePerSecond = 1F;
    public float nextAttackTimeLeft = 0F;
    protected bool canAttack = false;

    public BaseStatement baseStatement;
    public Transform canvasTransform;

    public GameObject enemyObject;
    public GameObject enemyBaseObject;
    protected float dist;
    // Use this for initialization
    protected void Awake()
    {
        baseStatement = GetComponent<BaseStatement>();
        canvasTransform = transform.parent.Find("EnemyStatementCanvas");
    }

	// Use this for initialization
	protected void Start () {
        
	}
	
	// Update is called once per frame
	protected void Update () {
        if (!GameStatement.gameStatement.paused && GameStatement.levelStatementIsDone)
        {
            if (checkAttack())
            {
                if (enemyObject == null)
                {
                    if (enemyBaseObject != null)
                    {
                        enemyObject = enemyBaseObject;
                    }
                    else
                    {
                        enemyObject = PlayerBaseStatement.player;
                    }
                }
                setCanvasTransform(enemyObject);
                dist = Vector3.Distance(transform.position, enemyObject.transform.position);
                if (dist < attackDistance)
                {
                    attack(enemyObject);
                }
                else
                {
                    move(enemyObject.transform.position);
                }
                if (enemyBaseObject == null)
                {
                    enemyObject = resetEnemyObject();
                }
            }
        }
	}

    protected virtual bool checkAttack()
    {
        if (!canAttack)
        {
            nextAttackTimeLeft -= Time.deltaTime;
            if (nextAttackTimeLeft <= 0)
            {
                nextAttackTimeLeft = 1 / attackTimePerSecond;
                canAttack = true;
            }
        }
        return canAttack;
    }

    protected virtual void setCanvasTransform(GameObject enemy)
    {
        if (enemy == null)
        {
            return;
        }
        canvasTransform.LookAt(enemy.transform.position, Vector3.up);
    }

    protected virtual void attack(GameObject enemy)
    {
        
    }

    protected virtual void move(Vector3 enemyPosition)
    {
        transform.position = transform.position + (enemyPosition - transform.position).normalized * moveSpeed * Time.deltaTime; ;
    }

    protected virtual GameObject resetEnemyObject()
    {
        return null;
    }

    public virtual void setBaseEnemyObject(GameObject obj)
    {
        enemyBaseObject = obj;
        enemyObject = obj;
    }

    public virtual GameObject getBaseEnemyObject()
    {
        return enemyBaseObject;
    }
}
