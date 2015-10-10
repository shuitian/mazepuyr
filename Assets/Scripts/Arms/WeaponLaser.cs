using UnityEngine;
using System.Collections;

public class WeaponLaser : WeaponBase
{
    public override bool shoot()
    {
        if (!base.shoot())
        {
            return false;
        }
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (!hit.collider.isTrigger)
            {
                return true; ;
            }
            SkillGetDamaged skillGetDamaged = hit.collider.gameObject.GetComponent<SkillGetDamaged>();
            if (skillGetDamaged == null || skillGetDamaged.getDamagedStatement == null || skillGetDamaged.getDamagedStatement.gameObject == null || shooterStatement == null)
            {
                return true;
            }
            BaseStatement getDamagedStatement = skillGetDamaged.getDamagedStatement;
            if (((getDamagedStatement.tag.IndexOf(shooterStatement.tag) <= -1) && (shooterStatement.tag.IndexOf(getDamagedStatement.tag) <= -1)) && ((getDamagedStatement.tag.IndexOf("Enemy") > -1) || getDamagedStatement.tag.IndexOf("Player") > -1))
            {
                getDamagedStatement.loseHp(shooterStatement, shooterStatement.baseAttackPerLevel[shooterStatement.level] * (1 - getDamagedStatement.baseDefensePerLevel[getDamagedStatement.level]));
            }
        }
        return true;
    }
}
