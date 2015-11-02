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
    public float[] baseDefensePerLevel = { 0F, 0.1F, 0.15F, 0.2F, 0.25F, 0.3F, 0.35F, 0.4F, 0.4F, 0.4F, 0.4F, 0.4F };

    public float recoverHpPerSecond = 1;
    public float recoverMpPerSecond = 1;

    public bool isDead = false;
    protected Mutex dieMutex;

    public float expGetRate = 0.3F;
    public BaseStatement fatherStatemnt;
    public float fatherStatemntExpGetRate = 0.25F;
    public int childNumber = 0;

	// Use this for initialization
	protected void Awake () {
        dieMutex = new Mutex();
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
    }

    void Start()
    {
        StartCoroutine(RecoverCoroutine());
    }

    IEnumerator RecoverCoroutine()
    {
        while (true)
        {
            recoverHp(recoverHpPerSecond * Time.deltaTime);
            recoverMp(recoverMpPerSecond * Time.deltaTime);
            yield return 0;
        }
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
        if (!isPositionRight())
        {
            return false;
        }
        return true;
    }

    public virtual bool isPositionRight()
    {
        if (LevelBaseStatement.levelStatementIsDone)
        {
            if (transform.position.y < LevelBaseStatement.levelBaseStatement.terrainMinY
                   || transform.position.x < LevelBaseStatement.levelBaseStatement.terrainMinX
                       || transform.position.z < LevelBaseStatement.levelBaseStatement.terrainMinZ
                           || transform.position.x > LevelBaseStatement.levelBaseStatement.terrainMaxX
                               || transform.position.y > LevelBaseStatement.levelBaseStatement.terrainMaxY
                                   || transform.position.z > LevelBaseStatement.levelBaseStatement.terrainMaxZ)
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
        if (mp < losedMp)
        {
            return false;
        }
        else
        {
            mp -= losedMp;
            return true;
        }
    }

    public virtual float recoverHp(float recover)
    {
        if (recover <= 0)
        {
            return 0;
        }
        float hpTemp = hp;
        hp += recover;
        if (hp > maxHp[level])
        {
            hp = maxHp[level];
        }
        return hp - hpTemp;
    }

    public virtual float recoverMp(float recover)
    {
        if (recover <= 0)
        {
            return 0;
        }
        float mpTemp = mp;
        mp += recover;
        if (mp > maxMp[level])
        {
            mp = maxMp[level];
        }
        return mp - mpTemp;
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
