using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyBaseStatement : BaseStatement
{
    //public float attackDistance = 1F;
    //public float moveSpeed = 1F;
    //public float attackTimePerSecond = 1F;
    //public float nextAttackTimeLeft = 0F;
    //protected bool canAttack = false;

    //public GameObject enemyObject;
    //public GameObject enemyBaseObject;
    //protected float dist;

    protected bool dead = false;
    public  GameObject obj;
    public GUIEnemyBaseStatementShow enemyBaseStatementShow;
    public Transform enemyStatementCanvas;

    Vector3 baseScale;
    public float baseGrowScaleExp;
	// Use this for initialization
    protected void Awake () {
        base.Awake();
        maxHp = new float[] { 0F, 100F, 200F, 300F, 400F, 500F, 700F, 1000F, 1500F, 2500F, 4000F, 10000F };
        maxMp = new float[] { 0F, 10F, 20F, 30F, 40F, 50F, 60F, 70F, 80F, 90F, 100F, 110F };
        maxExpPerLevel = new float[] { 0F, 1F, 1F, 2F, 4F, 8F, 16F, 32F, 40F, 45F, 50F, 55F };
        baseAttackPerLevel = new float[] { 0F, 5F, 5F, 10F, 15F, 20F, 25F, 30F, 35F, 40F, 45F, 50F };//, 55F };
        baseDefensePerLevel = new float[] { 0F, 0F, 1F, 2F, 3F, 4F, 5F, 6F, 7F, 8F, 9F, 10F};//, 11F };
        dead = false;
        baseGrowScaleExp = 1;
        dieMutex = new Mutex();
	}

    protected void Start()
    {
        base.Start();
        if (transform.parent != null)
        {
            baseScale = transform.parent.localScale;
            enemyBaseStatementShow = transform.parent.GetComponentInChildren<GUIEnemyBaseStatementShow>();
            enemyStatementCanvas = enemyBaseStatementShow.transform;

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

    public override bool die(BaseStatement killer)//try-catch
    {
        if (base.die(killer) == true)
        {
            Destroy(transform.parent.gameObject);
            GameStatement.gameStatement.subEnemyAlive();
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
        enemyBaseStatementShow.updateHpText(hp, maxHp[level]);
    }

    public override void getExp(BaseStatement expFrom, float e)
    {
        base.getExp(expFrom, e);
        transform.localScale = (1 + totalExp / baseGrowScaleExp) * Vector3.one;
        enemyStatementCanvas.localScale = (1 + totalExp / baseGrowScaleExp) * 0.005F * Vector3.one;
        enemyBaseStatementShow.updateExpText(exp, maxExpPerLevel[level]);
    }

    public override void growLevel(int l)
    {
        base.growLevel(l);
        enemyBaseStatementShow.updateLevelText(level);
        enemyBaseStatementShow.updateHpText(hp, maxHp[level]);
        enemyBaseStatementShow.updateMpText(mp, maxMp[level]);
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
