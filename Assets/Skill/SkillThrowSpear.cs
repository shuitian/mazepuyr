using UnityEngine;
using System.Collections;

public class SkillThrowSpear : MonoBehaviour
{
    public GameObject toBeAttacked;
    public GameObject attacker;

    public BaseStatement attackerStatement;

    public int checkDistFrames = 10;
    public float attackDistance = 10;
    public float attackTimePerSecond = 1;

    protected bool inAttackDistance;
    protected float lastAttackTime = 0;

    public GameObject bulletPrefab;
    int i;
    protected void Awake()
    {
    }
	// Use this for initialization
    protected void Start()
    {
	}

    protected void OnEnable()
    {
        toBeAttacked = PlayerBaseStatement.player;
        i = 0;
    }

    protected void FixedUpdate()
    {
        if (!toBeAttacked)
        {
            return;
        }
        if (i++ > checkDistFrames) 
        {
            i = 0;
            float dist = Vector3.Distance(toBeAttacked.transform.position, attacker.transform.position);
            if (dist < attackDistance)
            {
                inAttackDistance = true;
            }
            else
            {
                inAttackDistance = false;
            }
        }
    }

	// Update is called once per frame
    protected void Update()
    {
        if (inAttackDistance)
        {
            if (Time.time - lastAttackTime > 1 / attackTimePerSecond)
            {
                shoot();
                lastAttackTime = Time.time;
            }
        }
	}

    public void shoot()
    {
        if (bulletPrefab == null)
        {
            return;
        }
        GameObject clone = BulletPool.Bullet(bulletPrefab, attacker.transform.position, Quaternion.FromToRotation(Vector3.forward, (toBeAttacked.transform.position - attacker.transform.position).normalized)) as GameObject;
        BulletBaseParameter bulletBaseParameter = clone.GetComponent<BulletBaseParameter>();
        bulletBaseParameter.setDamage(clone.GetComponent<BulletBaseParameter>().getBaseDamage() + attackerStatement.baseAttackPerLevel[attackerStatement.level]);
        bulletBaseParameter.damager = attackerStatement;
    }

    public void setToBeAttacked(GameObject toBeAttacked)
    {
        this.toBeAttacked = toBeAttacked;
    }
}
