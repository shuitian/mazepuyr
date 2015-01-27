﻿using UnityEngine;
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
    public float[] baseDefensePerLevel = { 0F, 0.1F, 0.15F, 0.2F, 0.25F, 0.3F, 0.35F, 0.4F, 0.4F, 0.4F, 0.4F, 0.4F };

    public float recoverHpPerSecond = 1;
    public float recoverMpPerSecond = 1;

    public bool isDead = false;
    protected Mutex dieMutex;

    public float expGetRate = 0.3F;
    public BaseStatement fatherStatemnt;
    public float fatherStatemntExpGetRate = 0.25F;
    public int childNumber = 0;

    float time;
	// Use this for initialization
	protected void Awake () {
        dieMutex = new Mutex();
	}

    protected void Start()
    {
    }

    protected void OnEnable()
    {
        hp = maxHp[level];
        mp = maxMp[level];
        exp = 0;
        totalExp = 0;
        lifeRemain = maxLife;
        level = 1;
        isDead = false;
        fatherStatemnt = null;
        childNumber = 0;

        time = Time.time;
    }

	// Update is called once per frame
	protected void Update () {
        float t;
        if ((t = (Time.time))>  time+1)
        {
            recoverHp(recoverHpPerSecond);
            recoverMp(recoverMpPerSecond);
            time = t;
        }
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
        if (losedHp <= 1)
        {
            losedHp = 1;
        }
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

    public virtual bool loseMp(float losedMp)
    {
        if (losedMp <= 1)
        {
            losedMp = 1;
        }
        if (mp <= losedMp)
        {
            return false;
        }
        else
        {
            mp -= losedMp;
            return true;
        }
    }

    public virtual void recoverHp(float recover)
    {
        if (recover <= 0)
        {
            return;
        }
        hp += recover;
        if (hp > maxHp[level])
        {
            hp = maxHp[level];
        }
    }

    public virtual void recoverMp(float recover)
    {
        if (recover <= 0)
        {
            return;
        }
        mp += recover;
        if (mp > maxMp[level])
        {
            mp = maxMp[level];
        }
    }

    public virtual void getExp(BaseStatement expFrom, float e)
    {
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
        while (exp >= maxExpPerLevel[level] && level <= maxLevel)
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
}
