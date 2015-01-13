using UnityEngine;
using System.Collections;

public class BulletShooterControl : MonoBehaviour
{

    public GameObject bullet;
    public GameObject bulletStoneSpear;
    public Ray ray;
    public enum WeaponNumber : int
    {
        Bullet = 0,
        Ray = 1,
        BulletStoneSpear = 2,
    }
    static public WeaponNumber weaponNumber = WeaponNumber.BulletStoneSpear;

    GameObject clone;
    BulletBaseParameter bulletBaseParameter;
	// Use this for initialization
	void Start () {
        bullet = Resources.Load("Prefab/Arms/Bullet") as GameObject;
        bulletStoneSpear = Resources.Load("Prefab/Arms/BulletStoneSpear") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameStatement.levelStatementIsDone)
        {
            if (Input.GetMouseButton(0))
            {
                if (PlayerBaseStatement.playerBaseStatement.canAttack)
                {
                    shoot(weaponNumber);
                    PlayerBaseStatement.playerBaseStatement.canAttack = false;
                }
            }
            else if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                print(4);
            }
        }
	}

    void shoot( WeaponNumber weaponNumber)
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2,0));//Input.mousePosition); ;
        switch (weaponNumber)
        {
            case WeaponNumber.Bullet:
                clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                bulletBaseParameter = clone.GetComponent<BulletBaseParameter>();
                bulletBaseParameter.setDamage(bulletBaseParameter.getBaseDamage() + PlayerBaseStatement.playerBaseStatement.baseAttackPerLevel[PlayerBaseStatement.playerBaseStatement.level]);
                bulletBaseParameter.damager = PlayerBaseStatement.playerBaseStatement;

                clone.rigidbody.velocity = ray.direction * bulletBaseParameter.getSpeed();
                clone.transform.rotation = Quaternion.FromToRotation(Vector3.forward, ray.direction);

                clone.transform.parent = GameStatement.bulletGroup.transform;
                break;
            case WeaponNumber.Ray:
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag.IndexOf("Enemy") > -1)
                    {
                        hit.collider.gameObject.GetComponent<EnemyBaseStatement>().loseHp(PlayerBaseStatement.playerBaseStatement, 0 + PlayerBaseStatement.playerBaseStatement.baseAttackPerLevel[PlayerBaseStatement.playerBaseStatement.level]);
                    }
                }
                break;
            case WeaponNumber.BulletStoneSpear:
                clone = Instantiate(bulletStoneSpear, transform.position, transform.rotation) as GameObject;
                bulletBaseParameter = clone.GetComponent<BulletBaseParameter>();
                bulletBaseParameter.setDamage(clone.GetComponent<BulletBaseParameter>().getBaseDamage() + PlayerBaseStatement.playerBaseStatement.baseAttackPerLevel[PlayerBaseStatement.playerBaseStatement.level]);
                bulletBaseParameter.damager = PlayerBaseStatement.playerBaseStatement;

                clone.rigidbody.velocity = ray.direction * clone.GetComponent<BulletBaseParameter>().getSpeed();
                clone.transform.rotation = Quaternion.FromToRotation(Vector3.forward, ray.direction);

                clone.transform.parent = GameStatement.bulletGroup.transform;
                break;
            default:
                break;

        }
    }

    static public void setWeapon(WeaponNumber weapon)
    {
        weaponNumber = weapon;
    }
}
