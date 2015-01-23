using UnityEngine;
using System.Collections;

public class SkillShoot : MonoBehaviour {

    public BulletCrossHair crossHair;
    public LineRenderer lineRenderer;
    public GameObject shooter;
    public BaseStatement shooterStatement;

    public GameObject bullet;
    public GameObject bulletStoneSpear;

    public float shootTimePerSecond = 10;

    protected float lastShootTime = 0;

    Ray ray;
    RaycastHit hit;
    bool hitFalg;
    GameObject clone;
    BulletBaseParameter bulletBaseParameter;
    protected void Awake()
    {
        lineRenderer.enabled = false;
    }
    // Use this for initialization
    protected void Start()
    {
    }

    protected void OnEnable()
    {
    }

    // Update is called once per frame
    protected void Update()
    {
        if (GameStatement.levelStatementIsDone)
        {
            if (Input.GetMouseButton(0))
            {
                if (PlayerBaseStatement.playerBaseStatement.canAttack)
                {
                    if (Time.time - lastShootTime > 1 / shootTimePerSecond)
                    {
                        shoot(WeaponNumber.weaponNumber);
                        lastShootTime = Time.time;
                    }
                }
            }
        }
    }

    void shoot(WeaponNumber.Weapon weaponNumber)
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        switch (weaponNumber)
        {
            case WeaponNumber.Weapon.Bullet:
                clone = BulletPool.Bullet(bullet, transform.position, Quaternion.FromToRotation(Vector3.forward, ray.direction)) as GameObject;
                bulletBaseParameter = clone.GetComponent<BulletBaseParameter>();
                bulletBaseParameter.setDamage(bulletBaseParameter.getBaseDamage() + PlayerBaseStatement.playerBaseStatement.baseAttackPerLevel[PlayerBaseStatement.playerBaseStatement.level]);
                bulletBaseParameter.damager = PlayerBaseStatement.playerBaseStatement;

                break;
            case WeaponNumber.Weapon.Ray:
                hitFalg = Physics.Raycast(ray, out hit);
                if (hitFalg)
                {
                    if (!hit.collider.isTrigger)
                    {
                        return;
                    }
                    SkillGetDamaged skillGetDamaged = hit.collider.gameObject.GetComponent<SkillGetDamaged>();
                    if (skillGetDamaged == null || skillGetDamaged.getDamagedStatement == null || skillGetDamaged.getDamagedStatement.gameObject == null || shooter == null)
                    {
                        return;
                    }
                    if (((skillGetDamaged.getDamagedStatement.gameObject.tag.IndexOf(shooter.tag) <= -1) && (shooter.tag.IndexOf(skillGetDamaged.getDamagedStatement.gameObject.tag) <= -1)) && ((skillGetDamaged.getDamagedStatement.gameObject.tag.IndexOf("Enemy") > -1) || skillGetDamaged.getDamagedStatement.gameObject.tag.IndexOf("Player") > -1))
                    {
                        skillGetDamaged.getDamagedStatement.loseHp(shooterStatement, 0 + shooterStatement.baseAttackPerLevel[shooterStatement.level]);
                    }
                }
                break;
            case WeaponNumber.Weapon.BulletStoneSpear:
                clone = BulletPool.Bullet(bulletStoneSpear, transform.position, Quaternion.FromToRotation(Vector3.forward, ray.direction)) as GameObject;
                bulletBaseParameter = clone.GetComponent<BulletBaseParameter>();
                bulletBaseParameter.setDamage(clone.GetComponent<BulletBaseParameter>().getBaseDamage() + PlayerBaseStatement.playerBaseStatement.baseAttackPerLevel[PlayerBaseStatement.playerBaseStatement.level]);
                bulletBaseParameter.damager = PlayerBaseStatement.playerBaseStatement;

                break;
            default:
                break;

        }
    }
}
