using UnityEngine;
using System.Collections;
using System;

public class BulletBaseParameter : MonoBehaviour
{
//    var speed : float = 10;
//var lifeTime : float = 0.5;
//var dist : float = 10000;

//private var spawnTime : float = 0.0;
//private var tr : Transform;

//function OnEnable () {
//    tr = transform;
//    spawnTime = Time.time;
//}

//function Update () {
//    tr.position += tr.forward * speed * Time.deltaTime;
//    dist -= speed * Time.deltaTime;
//    if (Time.time > spawnTime + lifeTime || dist < 0) {
//        Spawner.Destroy (gameObject);
//    }
//}

    public float speed = 0;
    public float maxDist = 2000;
    public float damage = 0;
    public float baseDamage = 0;
    public BaseStatement damager;

    public float lifeTime = 10F;
    private float enableTime = 0F;
    private Transform enableTransform;
    private float dist;
    protected void Awake()
    {
    }

    protected void OnEnable()
    {
        dist = 0;
        enableTime = Time.time;
        enableTransform = transform;
    }

	// Use this for initialization
	protected void Start () {
        
	}
	
	// Update is called once per frame
	protected void Update () {
        if (GameStatement.levelStatementIsDone)
        {
            enableTransform.position += enableTransform.forward * speed * Time.deltaTime;
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
        try
        {
            if (((collider.gameObject.tag.IndexOf(damager.tag) <= -1) && (damager.tag.IndexOf(collider.gameObject.tag) <= -1)) && ((collider.gameObject.tag.IndexOf("Enemy") > -1) || collider.gameObject.tag.IndexOf("Player") > -1))
            {
                BulletPool.Destroy(gameObject);
            }
        }
        catch (Exception e)
        {
            BulletPool.Destroy(gameObject);
        }
    }
}
