﻿using UnityEngine;
using System.Collections;
using UnityTool.Libgame;

public class WeaponGrenadeLaucher : WeaponBase
{
    public override bool shoot()
    {
        if (bullet == null)
        {
            return false;
        }
        if (UnityEngine.Time.time - lastShootTime < 1 / shootTimePerSecond)
        {
            return false;
        }
        GrenadeParameter grenadeParameter = bullet.GetComponent<GrenadeParameter>();
        if (!shooterStatement.loseMp(grenadeParameter.costMp))
        {
            return false;
        }
        lastShootTime = UnityEngine.Time.time;
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        GameObject clone = ObjectPool.Instantiate(bullet, transform.position + transform.forward.normalized * 5, Quaternion.FromToRotation(Vector3.forward, ray.direction), GameStatement.gameStatement.bulletPoolTransform) as GameObject;
        grenadeParameter = clone.GetComponent<GrenadeParameter>();
        grenadeParameter.damager = shooterStatement;
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
