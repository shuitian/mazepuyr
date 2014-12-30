using UnityEngine;
using System.Collections;

public class ShooterControl : MonoBehaviour {

    public GameObject bullet;
    public Ray ray;
    public enum WeaponNumber : int
    {
        Bullet = 0,
        Ray = 1,
    }
    public float[] WeaponDamage = { 1, 1 };
    static public WeaponNumber weaponNumber = WeaponNumber.Ray;
    
        
	// Use this for initialization
	void Start () {
        bullet = Resources.Load("prefab/Bullet") as GameObject;
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            shoot(PlayerBaseStatement.playerBaseStatement, weaponNumber);
        }
	}

    void shoot(PlayerBaseStatement playerBaseStatement, WeaponNumber weaponNumber)
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2,0));//Input.mousePosition); ;
        switch (weaponNumber)
        {
            case WeaponNumber.Bullet:
                GameObject clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                clone.rigidbody.velocity = ray.direction* clone.GetComponent<BulletParameter>().getSpeed();//transform.TransformDirection(new Vector3(0, 0, clone.GetComponent<BulletParameter>().speed));
                clone.GetComponent<BulletParameter>().setDamage(PlayerStatement.baseAttackPerLevel[playerBaseStatement.level]);
                clone.GetComponent<BulletParameter>().playerBaseStatement = playerBaseStatement;
                clone.transform.parent = GameObject.FindGameObjectWithTag("BulletGroup").transform;
                clone.transform.rotation = Quaternion.FromToRotation(Vector3.forward, ray.direction);
                break;
            case WeaponNumber.Ray:
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100F))
                {
                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        hit.collider.gameObject.GetComponent<EnemyBaseStatement>().getDamaged(PlayerBaseStatement.playerBaseStatement, WeaponDamage[1]);
                    }
                }
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
