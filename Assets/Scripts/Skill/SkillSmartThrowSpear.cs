using UnityEngine;
using System.Collections;

public class SkillSmartThrowSpear : SkillThrowSpear
{
    public override Vector3 GetEnemyPosition()
    {
        //BulletBaseParameter bulletBaseParameter = bulletPrefab.GetComponent<BulletBaseParameter>();
        //float speed = bulletBaseParameter.getSpeed();
        return toBeAttacked.transform.position;
    }

    //protected new void FixedUpdate()
    //{
    //    if (!toBeAttacked || !toBeAttackedStatement)
    //    {
    //        return;
    //    }
    //    if (i++ > checkDistFrames)
    //    {
    //        i = 0;
    //        float dist = Vector3.Distance(toBeAttacked.transform.position, attacker.transform.position);
    //        if (dist < attackDistance)
    //        {
    //            inAttackDistance = true;
    //        }
    //        else
    //        {
    //            inAttackDistance = false;
    //        }
    //    }
    //}
}
