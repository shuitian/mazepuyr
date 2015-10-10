using UnityEngine;
using System.Collections;
using Regame;

public class WeaponHandGun : WeaponBase
{
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
        GameObject clone = ObjectPool.Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.forward, ray.direction), GameStatement.gameStatement.bulletPoolTransform) as GameObject;
        BulletBaseParameter bulletBaseParameter = clone.GetComponent<BulletBaseParameter>();
        bulletBaseParameter.setDamage(bulletBaseParameter.getBaseDamage() + shooterStatement.baseAttackPerLevel[shooterStatement.level]);
        bulletBaseParameter.damager = shooterStatement;
        return true;
    }
}
