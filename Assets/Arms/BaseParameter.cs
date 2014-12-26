using UnityEngine;
using System.Collections;

public class BaseParameter : MonoBehaviour
{

    protected float speed;
    protected float damage;
    public PlayerBaseStatement playerBaseStatement;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
}
