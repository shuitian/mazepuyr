using UnityEngine;
using System.Collections;

public class WeaponSpearThrower : WeaponBase
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}

    public override bool shoot()
    {
        if (bullet == null)
        {
            return false;
        }
        if (!base.shoot())
        {
            return false;
        }
        GameObject clone = BulletPool.Bullet(bullet, transform.position, Quaternion.FromToRotation(Vector3.forward, ray.direction)) as GameObject;
        BulletBaseParameter bulletBaseParameter = clone.GetComponent<BulletBaseParameter>();
        bulletBaseParameter.setDamage(bulletBaseParameter.getBaseDamage() + shooterStatement.baseAttackPerLevel[shooterStatement.level]);
        bulletBaseParameter.damager = shooterStatement;
        return true;
    }
}
