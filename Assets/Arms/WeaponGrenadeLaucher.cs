using UnityEngine;
using System.Collections;

public class WeaponGrenadeLaucher : WeaponBase
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
        if (!base.shoot())
        {
            return false;
        }
        if (bullet == null)
        {
            return false;
        }
        GameObject clone = BulletPool.Bullet(bullet, transform.position + transform.forward.normalized * 5, Quaternion.FromToRotation(Vector3.forward, ray.direction)) as GameObject;
        GrenadeParameter grenadeParameter = clone.GetComponent<GrenadeParameter>();
        grenadeParameter.damager = shooterStatement;
        shooterStatement.loseMp(grenadeParameter.costMp);
        return true;
    }

    public override bool checkShootInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            return true;
        }
        return false;
    }
}
