using UnityEngine;
using System.Collections;
using System;

public class EnemyRedSphereAI : EnemyBaseAI
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
            Vector3 p = (enemy.transform.position - transform.position).normalized;
            GameObject clone = Instantiate(bulletStoneSpear, transform.position, transform.rotation) as GameObject;
            BulletBaseParameter bulletBaseParameter = clone.GetComponent<BulletBaseParameter>();
            bulletBaseParameter.setDamage(clone.GetComponent<BulletBaseParameter>().getBaseDamage() + baseStatement.baseAttackPerLevel[baseStatement.level]);
            bulletBaseParameter.damager = baseStatement;

            clone.transform.parent = GameObject.FindGameObjectWithTag("BulletGroup").transform;
            clone.rigidbody.velocity = p * bulletBaseParameter.getSpeed();
            clone.transform.rotation = Quaternion.FromToRotation(Vector3.forward, p);

            canAttack = false;
        }
    }

    protected override GameObject resetEnemyObject()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, attackDistance);
        if (cols.Length > 0)
        {
            foreach (Collider col in cols)
            {
                if (col.gameObject.tag == "EnemyBlue")
                {
                    enemyObject = col.gameObject;
                    break;
                }
            }
        }
        return enemyObject;
    }
}
