using UnityEngine;
using System.Collections;

public class BulletParameter : BaseParameter
{
	// Use this for initialization
	void Start () {
              
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override float getSpeed()
    {
        speed = 100F;
        return speed;
    }

    public override void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public override float getDamage()
    {
        damage = 1F; 
        return damage;
    }

    public override void setDamage(float damage)
    {
        this.damage = damage;
    }
}
