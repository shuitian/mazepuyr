using UnityEngine;
using System.Collections;
using System;
using UnityTool.Libgame;

public class BulletBaseParameter : MonoBehaviour
{
    public float speed = 0;
    public float maxDist = 500;
    protected float damage = 0;
    public float baseDamage = 0;
    public BaseStatement damager;

    public float lifeTime = 4F;
    private float enableTime = 0F;
    private float dist;

    protected void OnEnable()
    {
        dist = 0;
        enableTime = UnityEngine.Time.time;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

	// Update is called once per frame
	protected void Update () {
        if (LevelBaseStatement.levelStatementIsDone)
        {
            dist += speed * UnityEngine.Time.deltaTime;
            if (transform.position.y < LevelBaseStatement.levelBaseStatement.terrainMinY
                || transform.position.x < LevelBaseStatement.levelBaseStatement.terrainMinX
                    || transform.position.z < LevelBaseStatement.levelBaseStatement.terrainMinZ
                        || transform.position.x > LevelBaseStatement.levelBaseStatement.terrainMaxX
                            || transform.position.y > LevelBaseStatement.levelBaseStatement.terrainMaxY
                                || transform.position.z > LevelBaseStatement.levelBaseStatement.terrainMaxZ
                                    || UnityEngine.Time.time > enableTime + lifeTime || dist > maxDist) 
            {
                ObjectPool.Destroy(gameObject);
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
                ObjectPool.Destroy(gameObject);
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
