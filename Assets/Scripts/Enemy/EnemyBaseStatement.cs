using UnityEngine;
using System.Collections;
using System.Threading;
using Regame;

public class EnemyBaseStatement : BaseStatement
{
    public GUIEnemyBaseStatementShow enemyBaseStatementShow;
    static public ArrayList patients = new ArrayList();
    Vector3 baseScale;
    public float baseGrowScaleExp = 1;
	// Use this for initialization
    protected void Awake () {
        base.Awake();
        baseScale = transform.localScale;
	}

    protected void OnEnable()
    {
        base.OnEnable();
        transform.localScale = baseScale;
        if (enemyBaseStatementShow != null)
        {
            enemyBaseStatementShow.updateHpText(hp, maxHp[level]);
            enemyBaseStatementShow.updateMpText(mp, maxMp[level]);
            enemyBaseStatementShow.updateExpText(exp, maxExpPerLevel[level]);
            enemyBaseStatementShow.updateNameText(name);
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
            //EnemyPool.patientsLock.WaitOne();
            if (patients.Contains(gameObject))
            {
                patients.Remove(gameObject);
            }
            //EnemyPool.patientsLock.ReleaseMutex();
            ObjectPool.Destroy(gameObject);
            Message.RaiseOneMessage<int>("SubEnemyAlive", this, 1);
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
        if (enemyBaseStatementShow != null)
        {
            enemyBaseStatementShow.updateHpText(hp, maxHp[level]);
        }
        //EnemyPool.patientsLock.WaitOne();
        if (!isDead && hp != maxHp[level] && !patients.Contains(gameObject)) 
        {
            patients.Add(gameObject);
        }
        //EnemyPool.patientsLock.ReleaseMutex();
    }

    public override bool loseMp(float losedMp)
    {
        if (base.loseMp(losedMp) && enemyBaseStatementShow != null)
        {
            enemyBaseStatementShow.updateMpText(mp, maxMp[level]);
            return true;
        }
        return false;
    }

    public override float recoverHp(float recover)
    {
        float ret = base.recoverHp(recover);
        if (enemyBaseStatementShow != null)
        {
            enemyBaseStatementShow.updateHpText(hp, maxHp[level]);
        }
        //EnemyPool.patientsLock.WaitOne();
        if ((isDead || hp == maxHp[level]) && patients.Contains(gameObject)) 
        {
            patients.Remove(gameObject);
        }
        //EnemyPool.patientsLock.ReleaseMutex();
        return ret;
    }

    public override float recoverMp(float recover)
    {
        float ret = base.recoverMp(recover);
        if (enemyBaseStatementShow != null) 
        {
            enemyBaseStatementShow.updateMpText(mp, maxMp[level]);
        }
        return ret;
    }

    public override void getExp(BaseStatement expFrom, float e)
    {
        base.getExp(expFrom, e);
        transform.localScale = (1 + totalExp / baseGrowScaleExp) * baseScale;
        if (enemyBaseStatementShow != null)
        {
            enemyBaseStatementShow.updateExpText(exp, maxExpPerLevel[level]);
        }
    }

    public override void growLevel(int l)
    {
        base.growLevel(l);
        if (enemyBaseStatementShow != null)
        {
            enemyBaseStatementShow.updateLevelText(level);
            enemyBaseStatementShow.updateHpText(hp, maxHp[level]);
            enemyBaseStatementShow.updateMpText(mp, maxMp[level]);
        }
    }
}
