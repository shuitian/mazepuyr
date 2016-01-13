using UnityEngine;
using System.Collections;
using UnityTool.Libgame;

public class SkillFollowBow : SkillThrowSpear
{
    public override void attack()
    {
        if (bulletPrefab != null)
        {
            base.attack();
            ((BulletFollowArrow)bulletBaseParameter).target = toBeAttackedStatement;
        }
    }
}
