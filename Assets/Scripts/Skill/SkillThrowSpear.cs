using UnityEngine;
using System.Collections;
using UnityTool.Libgame;

public class SkillThrowSpear : SkillAttack
{
    public GameObject bulletPrefab;
    protected BulletBaseParameter bulletBaseParameter;
    public override void attack()
    {
        if (bulletPrefab != null)
        {
            GameObject clone = ObjectPool.Instantiate(bulletPrefab, attacker.transform.position, Quaternion.FromToRotation(Vector3.forward, (GetEnemyPosition() - attacker.transform.position).normalized), GameStatement.gameStatement.bulletPoolTransform) as GameObject;
            bulletBaseParameter = clone.GetComponent<BulletBaseParameter>();
            bulletBaseParameter.setDamage(clone.GetComponent<BulletBaseParameter>().getBaseDamage() + attackerStatement.baseAttackPerLevel[attackerStatement.level]);
            bulletBaseParameter.damager = attackerStatement;
        }
    }


    public virtual Vector3 GetEnemyPosition()
    {
        return toBeAttacked.transform.position;
    }
}
