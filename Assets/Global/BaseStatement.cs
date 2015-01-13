using UnityEngine;
using System.Collections;
using System.Threading;
using System;

public class BaseStatement : MonoBehaviour {

    public float hp;
    public float mp;
    public float exp = 0;
    public float totalExp = 0;
    public float deadExp = 1;
    public int lifeRemain = 1;
    public int maxLife = 1;
    public int level = 1;
    public int maxLevel = 10;
    public float[] maxHp = {0F, 100F, 110F, 120F, 130F, 140F, 150F, 160F, 170F, 180F, 190F, 200F };
    public float[] maxMp = {0F, 100F, 110F, 120F, 130F, 140F, 150F, 160F, 170F, 180F, 190F, 200F };
    public float[] maxExpPerLevel = {0F, 5F, 10F, 15F, 20F, 25F, 30F, 35F, 40F, 45F, 50F, 55F };
    public float[] baseAttackPerLevel = {0F, 10F, 15F, 20F, 25F, 30F, 35F, 40F, 45F, 50F, 55F, 60F };
    public float[] baseDefensePerLevel = {0F, 0F, 1F, 2F, 3F, 4F, 5F, 6F, 7F, 8F, 9F, 10F };

    protected bool isDead = false;
    protected Mutex dieMutex;

    public float expGetRate = 0.3F;
    public BaseStatement fatherStatemnt;
    public float fatherStatemntExpGetRate = 0.25F;
    public int childNumber;

	// Use this for initialization
	protected void Awake () {
        exp = 0;
        totalExp = 0;
        deadExp = 1;
        lifeRemain = 1;
        maxLife = 1;
        level = 1;
        maxLevel = 10;
        childNumber = 0;
        dieMutex = new Mutex();
	}

    protected void Start()
    {
        hp = maxHp[level];
        mp = maxMp[level];
    }

	// Update is called once per frame
	protected void Update () {
        if (isDead == false && !isAlive())
        {
            die(this);
        }
	}

    public virtual bool isAlive()
    {
        if (GameStatement.gameStatement.paused)
        {
            return true;
        }
        if (!isPositionRight())
        {
            return false;
        }
        return true;
    }

    public virtual bool isPositionRight()
    {
        if (GameStatement.levelStatementIsDone)
        {
            if (transform.position.y < GameStatement.levelStatement.terrainMinY
                   || transform.position.x < GameStatement.levelStatement.terrainMinX
                       || transform.position.z < GameStatement.levelStatement.terrainMinZ
                           || transform.position.x > GameStatement.levelStatement.terrainMaxX
                               || transform.position.y > GameStatement.levelStatement.terrainMaxY
                                   || transform.position.z > GameStatement.levelStatement.terrainMaxZ)
            {
                return false;
            }
        }
        return true;
    }

    public virtual bool die(BaseStatement killer)
    {
        if (killer == null)
        {
            return false;
        }
        try
        {
            dieMutex.WaitOne();
            if (isDead == false)
            {
                isDead = true;
                killer.getExp(this, deadExp + totalExp * expGetRate);
                if (fatherStatemnt != null)
                {
                    fatherStatemnt.childNumber--;
                }
            }
        }
        finally
        {
            dieMutex.ReleaseMutex();
        }
        return isDead;
    }

    public virtual void loseHp(BaseStatement damager, float losedHp)
    {
        //print("loseHp: " + losedHp + " from " + damager);
        hp -= losedHp;
        if (hp <= 0)
        {
            lifeRemain--;
            if (lifeRemain > 0)
            {
                hp = maxHp[level];
            }
            else
            {
                die(damager);
            }
        }
    }

    public virtual void loseMp(float losedMp)
    {
    }

    public virtual void recoverHp(float hp)
    {
    }

    public virtual void recoverMp(float mp)
    {
    }

    public virtual void getExp(BaseStatement expFrom, float e)
    {
        //print("getExp: " + e +" from "+expFrom);
        if (expFrom == null)
        {
            return;
        }
        if (fatherStatemnt != null)
        {
            fatherStatemnt.getExp(expFrom, e * fatherStatemntExpGetRate);
            exp += e * (1 - fatherStatemntExpGetRate);
            totalExp += e * (1 - fatherStatemntExpGetRate);
        }
        else
        {
            exp += e;
            totalExp += e;
        }
        while (exp > maxExpPerLevel[level] && level <= maxLevel)
        {
            exp -= maxExpPerLevel[level];
            growLevel();
        }
    }

    public virtual void growLevel(int l = 1)
    {
        int oldLevel = level;
        level+=l;
        if (level >= maxLevel)
        {
            level = maxLevel;
        }
        hp += maxHp[level] - maxHp[oldLevel];
        mp += maxMp[level] - maxMp[oldLevel];
    }

    public virtual void setFatherStatemnt(BaseStatement father)
    {
        fatherStatemnt = father;
    }

    void OnTriggerEnter(Collider collider)
    {
        try
        {
            BulletBaseParameter bulletBaseParameter = collider.gameObject.GetComponent<BulletBaseParameter>();
            if (bulletBaseParameter.damager.tag == gameObject.tag)
            {
                return;
            }
            loseHp(bulletBaseParameter.damager, bulletBaseParameter.getDamage());
        }
        catch (Exception e)
        {
            print("BaseStatement: OnTriggerEnter: " + e);
        }
    }
}
