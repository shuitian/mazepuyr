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
    
        
	// Use this for initialization
	void Start () {
        bullet = Resources.Load("Prefab/Arms/Bullet") as GameObject;
        bulletStoneSpear = Resources.Load("Prefab/Arms/BulletStoneSpear") as GameObject;
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
                GameObject clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                clone.transform.parent = GameObject.FindGameObjectWithTag("BulletGroup").transform;
                clone.rigidbody.velocity = ray.direction * clone.GetComponent<BulletBaseParameter>().getSpeed();
                clone.GetComponent<BulletBaseParameter>().setDamage(clone.GetComponent<BulletBaseParameter>().getBaseDamage() + PlayerBaseStatement.playerBaseStatement.baseAttackPerLevel[PlayerBaseStatement.playerBaseStatement.level]);
                clone.GetComponent<BulletBaseParameter>().damager = PlayerBaseStatement.playerBaseStatement;
                
                clone.transform.rotation = Quaternion.FromToRotation(Vector3.forward, ray.direction);
                break;
            case WeaponNumber.Ray:
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100F))
                {
                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        hit.collider.gameObject.GetComponent<EnemyBaseStatement>().loseHp(PlayerBaseStatement.playerBaseStatement, 0 + PlayerBaseStatement.playerBaseStatement.baseAttackPerLevel[PlayerBaseStatement.playerBaseStatement.level]);
                    }
                }
                break;
            case WeaponNumber.BulletStoneSpear:
                GameObject clone1 = Instantiate(bulletStoneSpear, transform.position, transform.rotation) as GameObject;
                BulletBaseParameter bulletBaseParameter = clone1.GetComponent<BulletBaseParameter>();
                bulletBaseParameter.setDamage(clone1.GetComponent<BulletBaseParameter>().getBaseDamage() + PlayerBaseStatement.playerBaseStatement.baseAttackPerLevel[PlayerBaseStatement.playerBaseStatement.level]);
                bulletBaseParameter.damager = PlayerBaseStatement.playerBaseStatement;
                clone1.tag = tag;

                clone1.transform.parent = GameObject.FindGameObjectWithTag("BulletGroup").transform;
                clone1.rigidbody.velocity = ray.direction * clone1.GetComponent<BulletBaseParameter>().getSpeed();
                clone1.transform.rotation = Quaternion.FromToRotation(Vector3.forward, ray.direction);
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
