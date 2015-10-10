using UnityEngine;
using System.Collections;

public class SkillShoot : MonoBehaviour
{

    public GameObject shooter;
    public BaseStatement shooterStatement;

    public WeaponHandGun weaponHandGun;
    public WeaponLaser weaponLaser;
    public WeaponSpearThrower weaponSpearThrower;

    void Awake()
    {
        if (WeaponNumber.weaponNumber == WeaponNumber.Weapon.Bullet)
        {
            weaponHandGun.enabled = true;
            weaponLaser.enabled = false;
            weaponSpearThrower.enabled = false;
        }
        else if (WeaponNumber.weaponNumber == WeaponNumber.Weapon.Ray)
        {
            weaponHandGun.enabled = false;
            weaponLaser.enabled = true;
            weaponSpearThrower.enabled = false;
        }
        else// if (WeaponNumber.weaponNumber == WeaponNumber.Weapon.BulletStoneSpear)
        {
            weaponHandGun.enabled = false;
            weaponLaser.enabled = false;
            weaponSpearThrower.enabled = true;
        }
    }
}
