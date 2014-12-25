using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyStatement : MonoBehaviour {

    private float hp;
    public float maxHp = 1F;
    private float mp;
    public float maxMp = 1F;
    public float exp = 1;
    public float attack = 1;
    public float defense = 0;
    public int level = 1;
    private bool dead = false;
    private Mutex mutex;
	// Use this for initialization
	void Start () {
        maxHp = 1F;
        hp = maxHp;
        maxMp = 1F;
        mp = maxMp;
        exp = 1;
        attack = 1;
        defense = 0;
        level = 1;
        dead = false;
        mutex = new Mutex();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void setEnemyStatement(EnemyStatement enemyStatement)
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

    void OnTriggerEnter(Collider collider)
    {
        damaged(collider.gameObject.GetComponent<BulletParameter>().playerStatement, collider.gameObject.GetComponent<BulletParameter>().damage);
        //Debug.Log("3");
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("4");
    }

    void die(PlayerStatement player)
    {
        mutex.WaitOne();
        if (dead == false)
        {
            dead = true;
            player.getExp(exp);
            Destroy(gameObject);
            GameStatement.gameStatement.enemiesAlive--;
            EnemiesNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
            if (GameStatement.gameStatement.enemiesAlive <= 0)
            {
                player.passLevel();
            }
        }
        mutex.ReleaseMutex();
    }

    public void damaged(PlayerStatement player, float damage)
    {
        hp -= (damage-defense);
        if (hp <= 0)
        {
            die(player);
        }
    }
}
