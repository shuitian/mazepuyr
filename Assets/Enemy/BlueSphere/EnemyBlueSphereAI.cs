using UnityEngine;
using System.Collections;
using System;

public class EnemyBlueSphereAI : EnemyBaseAI
{
    GameObject bulletStoneSpear;
    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
    }

    // Use this for initialization
    protected void Start()
    {
        base.Start();
        attackDistance = 150F;
        moveSpeed = 15F;
        attackTimePerSecond = 0.5F;
        bulletStoneSpear = Resources.Load("Prefab/Arms/BulletStoneSpear") as GameObject;
    }

    // Update is called once per frame
    protected void Update()
    {
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
            GameObject clone = BulletPool.Bullet(bulletStoneSpear, transform.position, Quaternion.FromToRotation(Vector3.forward, (enemy.transform.position - transform.position).normalized)) as GameObject;
            BulletBaseParameter bulletBaseParameter = clone.GetComponent<BulletBaseParameter>();
            bulletBaseParameter.setDamage(clone.GetComponent<BulletBaseParameter>().getBaseDamage() + baseStatement.baseAttackPerLevel[baseStatement.level]);
            bulletBaseParameter.damager = baseStatement;

            canAttack = false;
        }
    }

    protected override GameObject resetEnemyObject()
    {
        Collider[]  cols = Physics.OverlapSphere(transform.position, attackDistance);
        if (cols.Length > 0)
        {
            foreach (Collider col in cols)
            {
                if (col.gameObject.tag == "EnemyRed")
                {
                    enemyObject = col.gameObject;
                    break;
                }
            }
        }
        return enemyObject;
    }
}
