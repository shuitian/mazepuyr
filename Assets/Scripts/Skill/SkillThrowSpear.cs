using UnityEngine;
using System.Collections;
using Regame;

public class SkillThrowSpear : SkillAttack
{
    public GameObject bulletPrefab;

    public override void attack()
    {
        if (bulletPrefab == null)
        {
            return;
        }
        GameObject clone = ObjectPool.Instantiate(bulletPrefab, attacker.transform.position, Quaternion.FromToRotation(Vector3.forward, (toBeAttacked.transform.position - attacker.transform.position).normalized), GameStatement.gameStatement.bulletPoolTransform) as GameObject;
        BulletBaseParameter bulletBaseParameter = clone.GetComponent<BulletBaseParameter>();
        bulletBaseParameter.setDamage(clone.GetComponent<BulletBaseParameter>().getBaseDamage() + attackerStatement.baseAttackPerLevel[attackerStatement.level]);
        bulletBaseParameter.damager = attackerStatement;
    }
}
