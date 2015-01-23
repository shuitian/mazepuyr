using UnityEngine;
using System.Collections;

public class WeaponNumber {

    public enum Weapon : int
    {
        Bullet = 0,
        Ray = 1,
        BulletStoneSpear = 2,
    }
    static public Weapon weaponNumber = Weapon.BulletStoneSpear;

    static public void setWeapon(Weapon weapon)
    {
        weaponNumber = weapon;
    }
}
