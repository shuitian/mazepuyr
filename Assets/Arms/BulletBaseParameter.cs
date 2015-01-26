using UnityEngine;
using System.Collections;
using System;

public class BulletBaseParameter : MonoBehaviour
{

    public float speed = 0;
    public float maxDist = 500;
    protected float damage = 0;
    public float baseDamage = 0;
    public BaseStatement damager;

    public float lifeTime = 4F;
    private float enableTime = 0F;
    private Transform enableTransform;
    private float dist;

    // Use this for initialization
    protected void Awake()
    {
    }

	// Use this for initialization
	protected void Start () {
        
	}

    protected void OnEnable()
    {
        dist = 0;
        enableTime = Time.time;
        enableTransform = transform;
        rigidbody.velocity = enableTransform.forward * speed;
    }

	// Update is called once per frame
	protected void Update () {
        if (GameStatement.levelStatementIsDone)
        {    
            dist += speed * Time.deltaTime;
            if (transform.position.y < GameStatement.levelStatement.terrainMinY
                || transform.position.x < GameStatement.levelStatement.terrainMinX
                    || transform.position.z < GameStatement.levelStatement.terrainMinZ
                        || transform.position.x > GameStatement.levelStatement.terrainMaxX
                            || transform.position.y > GameStatement.levelStatement.terrainMaxY
                                || transform.position.z > GameStatement.levelStatement.terrainMaxZ
                                    || Time.time > enableTime + lifeTime || dist > maxDist) 
            {
                BulletPool.Destroy(gameObject);
            }
        }
	}

    public virtual float getSpeed()
    {
        return speed;
    }

    public virtual void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public virtual float getDamage()
    {
        return damage;
    }

    public virtual void setDamage(float damage)
    {
        this.damage = damage;
    }

    public virtual float getBaseDamage()
    {
        return baseDamage;
    }

    protected void OnTriggerEnter(Collider collider)
    {
        if (!collider.isTrigger)
        {
            return;
        }
        try
        {
            SkillGetDamaged skillGetDamaged = collider.gameObject.GetComponent<SkillGetDamaged>();
            if (skillGetDamaged == null || skillGetDamaged.getDamagedStatement == null || skillGetDamaged.getDamagedStatement.tag == null || damager == null)
            {
                return;
            }
            if (!isFriend(damager.tag, skillGetDamaged.getDamagedStatement.tag))
            {
                BulletPool.Destroy(gameObject);
            }
        }
        catch (Exception e)
        {
            print(e);
        }
    }

    bool isFriend(string tag1, string tag2)
    {
        if (((tag1.IndexOf(tag2) <= -1) && (tag2.IndexOf(tag1) <= -1)) && ((tag2.IndexOf("Enemy") > -1) || tag2.IndexOf("Player") > -1))
        {
            return false;
        }
        return true;
    }
}
