using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyBaseStatement : MonoBehaviour {

    protected float hp;
    public float maxHp = 1F;
    protected float mp;
    public float maxMp = 1F;
    public float exp = 1;
    public float attack = 1;
    public float defense = 0;
    public int level = 1;
    protected bool dead = false;
    protected Mutex dieMutex;
    public  GameObject obj;
    public EnemyBaseStatementShow enemyBaseStatementShow;
	// Use this for initialization
    protected void Start () {
        hp = maxHp;
        mp = maxMp;
        dead = false;
        dieMutex = new Mutex();
	}
	
	// Update is called once per frame
	protected void Update () {
        if (!isPositionRight())
        {
            //print("Destroy");
            //print(transform.position);
            Destroy(gameObject.transform.parent.gameObject);
            GameStatement.gameStatement.enemiesAlive--;
            EnemiesNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
        }
	}

    public bool isPositionRight()
    {
        try
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
        }
        finally
        {
        }
        return true;
    }

    public void setEnemyStatement(EnemyBaseStatement enemyStatement)
    {
        this.hp = enemyStatement.hp;
        this.maxHp = enemyStatement.maxHp;
        this.mp = enemyStatement.mp;
        this.maxMp = enemyStatement.maxMp;
        this.exp = enemyStatement.exp;
        this.attack = enemyStatement.attack;
        this.defense = enemyStatement.defense;
        this.level = enemyStatement.level;
    }

    public void getDamaged(PlayerBaseStatement player, float damage)
    {
        if (player == null)
        {
            return;
        }
        hp -= (damage - defense);
        if (hp <= 0)
        {
            die(player);
        }
        try
        {
            gameObject.transform.parent.GetComponentInChildren<EnemyBaseStatementShow>().updateHpText(hp, maxHp);
        }
        finally
        {
        }
    }

    protected virtual void die(PlayerBaseStatement player)//try-catch
    {
        if (player == null)
        {
            return;
        }
        dieMutex.WaitOne();
        if (dead == false)
        {
            //print(player);
            dead = true;
            player.getExp(exp);
            Destroy(gameObject.transform.parent.gameObject);
            GameStatement.gameStatement.enemiesAlive--;
            EnemiesNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
            if (GameStatement.gameStatement.enemiesAlive <= 0)
            {
                player.passLevel();
            }
        }
        dieMutex.ReleaseMutex();
    }

    public void setEnemyObject(string prefabPath)
    {
        obj = Resources.Load(prefabPath) as GameObject;
    }

    public void setEnemyObject(GameObject o)
    {
        obj = o;
    }

    public GameObject getObj()
    {
        return obj;
    }
}
