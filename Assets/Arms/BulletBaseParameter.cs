using UnityEngine;
using System.Collections;
using System;

public class BulletBaseParameter : MonoBehaviour
{

    public float speed;
    public float damage;
    public float baseDamage;
    public BaseStatement damager;

    protected void Awake()
    {
        baseDamage = 0;
        speed = 0;
    }

	// Use this for initialization
	protected void Start () {
        
	}
	
	// Update is called once per frame
	protected void Update () {
        if (GameStatement.levelStatementIsDone)
        {
            if (transform.position.y < GameStatement.levelStatement.terrainMinY
                || transform.position.x < GameStatement.levelStatement.terrainMinX
                    || transform.position.z < GameStatement.levelStatement.terrainMinZ
                        || transform.position.x > GameStatement.levelStatement.terrainMaxX
                            || transform.position.y > GameStatement.levelStatement.terrainMaxY
                                || transform.position.z > GameStatement.levelStatement.terrainMaxZ)
            {
                Destroy(gameObject);
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
        try
        {
            if (((collider.gameObject.tag.IndexOf(damager.tag) <= -1) && (damager.tag.IndexOf(collider.gameObject.tag) <= -1)) && ((collider.gameObject.tag.IndexOf("Enemy") > -1) || collider.gameObject.tag.IndexOf("Player") > -1))
            {
                Destroy(gameObject);
            }
        }
        catch (Exception e)
        {
            Destroy(gameObject);
        }
    }
}
