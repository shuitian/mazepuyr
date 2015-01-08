using UnityEngine;
using System.Collections;
using System.Threading;

public class BaseStatement : MonoBehaviour {

    public float hp;
    public float mp;
    public float exp = 0;
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

	// Use this for initialization
	protected void Awake () {
        exp = 0;
        deadExp = 1;
        lifeRemain = 1;
        maxLife = 1;
        level = 1;
        maxLevel = 10;
        dieMutex = new Mutex();
	}

    protected void Start()
    {
        hp = maxHp[level];
        mp = maxMp[level];
    }

	// Update is called once per frame
	protected void Update () {
        //if (isDead == false && !isAlive())
        //{
        //    die(new BaseStatement());
        //}
	}

    public virtual bool isAlive()
    {
        if (GameStatement.gameStatement.paused)
        {
            return true;
        }
        if (gameObject == null)
        {
            return false;
        }
        if (lifeRemain <= 0)
        {
            return false;
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
        dieMutex.WaitOne();
        if (isDead == false)
        {
            isDead = true;
            killer.getExp(this, deadExp);
        }
        dieMutex.ReleaseMutex();
        return true;
    }

    public virtual void loseHp(BaseStatement damager, float losedHp)
    {
        print(losedHp);
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
        exp += e;
        while (exp > maxExpPerLevel[level] && level <= maxLevel)
        {
            exp -= maxExpPerLevel[level];
            level++;
            hp += maxHp[level] - maxHp[level - 1];
            mp += maxMp[level] - maxMp[level - 1];
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<BulletBaseParameter>().tag == gameObject.tag)
        {
            return;
        }
        loseHp(collider.gameObject.GetComponent<BulletBaseParameter>().damager, collider.gameObject.GetComponent<BulletBaseParameter>().getDamage());
    }
}
