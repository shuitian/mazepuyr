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
    public WeaponNumber weaponNumber;
    
        
	// Use this for initialization
	void Start () {
        weaponNumber = WeaponNumber.Bullet;
        bullet = Resources.Load("prefab/Bullet") as GameObject;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            print(weaponNumber);
            shoot(PlayerStatement.playerStatement, weaponNumber);
        }
	}

    void shoot(PlayerStatement playerStatement, WeaponNumber weaponNumber)
    {
        Ray ray;
        switch (weaponNumber)
        {
            case WeaponNumber.Bullet:
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                
                GameObject clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                clone.rigidbody.velocity = ray.direction* clone.GetComponent<BulletParameter>().speed;//transform.TransformDirection(new Vector3(0, 0, clone.GetComponent<BulletParameter>().speed));
                clone.GetComponent<BulletParameter>().damage = PlayerStatement.baseAttackPerLevel[playerStatement.level];
                clone.GetComponent<BulletParameter>().playerStatement = playerStatement;
                clone.transform.parent = GameObject.FindGameObjectWithTag("BulletGroup").transform;
                clone.transform.rotation = Quaternion.FromToRotation(Vector3.forward, ray.direction);
                break;
            case WeaponNumber.Ray:
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100F))
                {
                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        hit.collider.gameObject.GetComponent<EnemyStatement>().damaged(PlayerStatement.playerStatement, WeaponDamage[1]);
                    }
                }
                break;
            default:
                break;

        }
    }
}
