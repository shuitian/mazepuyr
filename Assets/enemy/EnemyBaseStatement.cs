using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyBaseStatement : BaseStatement
{
    protected bool dead = false;
    protected Mutex dieMutex;
    public  GameObject obj;
    public GUIEnemyBaseStatementShow enemyBaseStatementShow;
	// Use this for initialization
    protected void Awake () {
        base.Awake();
        maxHp = new float[] { 0F, 10F, 20F, 30F, 40F, 50F, 60F, 70F, 80F, 90F, 100F, 110F };
        maxMp = new float[] { 0F, 10F, 20F, 30F, 40F, 50F, 60F, 70F, 80F, 90F, 100F, 110F };
        maxExpPerLevel = new float[] { 0F, 1F, 5F, 10F, 20F, 25F, 30F, 35F, 40F, 45F, 50F, 55F };
        baseAttackPerLevel = new float[] { 0F, 5F, 10F, 15F, 20F, 25F, 30F, 35F, 40F, 45F, 50F, 55F };
        baseDefensePerLevel = new float[] { 0F, 0F, 1F, 2F, 3F, 4F, 5F, 6F, 7F, 8F, 9F, 10F };
        dead = false;
        dieMutex = new Mutex();
	}

    protected void Start()
    {
        base.Start();
        if (transform.parent != null)
        {
            enemyBaseStatementShow = transform.parent.GetComponentInChildren<GUIEnemyBaseStatementShow>();
            enemyBaseStatementShow.updateHpText(hp, maxHp[level]);
            enemyBaseStatementShow.updateMpText(mp, maxMp[level]);
            enemyBaseStatementShow.updateExpText(exp, maxExpPerLevel[level]);
            enemyBaseStatementShow.updateNameText(transform.parent.gameObject.name);
            enemyBaseStatementShow.updateLevelText(level);
        }
    }

	// Update is called once per frame
	protected void Update () {
        base.Update();
	}


    //public void setEnemyStatement(EnemyBaseStatement enemyStatement)
    //{
    //    this.hp = enemyStatement.hp;
    //    this.maxHp = enemyStatement.maxHp;
    //    this.mp = enemyStatement.mp;
    //    this.maxMp = enemyStatement.maxMp;
    //    this.exp = enemyStatement.exp;
    //    this.attack = enemyStatement.attack;
    //    this.defense = enemyStatement.defense;
    //    this.level = enemyStatement.level;
    //}

    public override bool die(BaseStatement killer)//try-catch
    {
        if (base.die(killer) == true)
        {
            Destroy(transform.parent.gameObject);
            GameStatement.gameStatement.enemiesAlive--;
            GUIEnemyNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void loseHp(BaseStatement damager, float losedHp)
    {
        base.loseHp(damager, losedHp);
        gameObject.transform.parent.GetComponentInChildren<GUIEnemyBaseStatementShow>().updateHpText(hp, maxHp[level]);
    }

    public override void getExp(BaseStatement expFrom, float e)
    {
        base.getExp(expFrom, e);
        gameObject.transform.parent.GetComponentInChildren<GUIEnemyBaseStatementShow>().updateExpText(exp, maxExpPerLevel[level]);
        gameObject.transform.parent.GetComponentInChildren<GUIEnemyBaseStatementShow>().updateLevelText(level);
        gameObject.transform.parent.GetComponentInChildren<GUIEnemyBaseStatementShow>().updateHpText(hp, maxHp[level]);
        gameObject.transform.parent.GetComponentInChildren<GUIEnemyBaseStatementShow>().updateMpText(mp, maxMp[level]);
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
