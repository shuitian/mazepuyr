using UnityEngine;
using System.Collections;

public class PlayerBaseStatement : BaseStatement {

    public float attackTimePerSecond = 10F;
    protected float nextAttackTimeLeft = 0F;
    public bool canAttack = false;
    static public PlayerBaseStatement playerBaseStatement;
    static public GameObject player;

    private bool isPositionSet;
	// Use this for initialization
	protected void Awake () {
        base.Awake();
        playerBaseStatement = this;
        player = gameObject;
        isPositionSet = false;

        Message.RegeditMessageHandle(new Message.LEVELISDONE(), showInitStatement);
	}

    protected  void Start()
    {
        base.Start();
    }

	// Update is called once per frame
	protected void Update () {
        base.Update();
        if (!isPositionSet && GameStatement.levelStatementIsDone)
        {
            transform.position = GameStatement.levelStatement.bornPosition;
            isPositionSet = true;
        }
        if (!canAttack)
        {
            nextAttackTimeLeft -= Time.deltaTime;
        }
        if (nextAttackTimeLeft <= 0)
        {
            nextAttackTimeLeft = 1 / attackTimePerSecond;
            canAttack = true;
        }
	}
    public override bool die(BaseStatement killer)
    {
        if (base.die(killer) == true)
        {
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
        GUIPlayerStatementShow.playerStatementShow.updateHpText(hp, maxHp[level]);
    }

    public override bool loseMp(float losedMp)
    {
        if (base.loseMp(losedMp))
        {
            GUIPlayerStatementShow.playerStatementShow.updateMpText(mp, maxMp[level]);
            return true;
        }
        return false;
    }

    public override float recoverHp(float recover)
    {
        float ret = base.recoverHp(recover);
        GUIPlayerStatementShow.playerStatementShow.updateHpText(hp, maxHp[level]);
        return ret;
    }

    public override float recoverMp(float recover)
    {
        float ret = base.recoverMp(recover);
        GUIPlayerStatementShow.playerStatementShow.updateMpText(mp, maxMp[level]);
        return ret;
    }

    public override void getExp(BaseStatement expFrom, float e)
    {
        base.getExp(expFrom, e);
        GUIPlayerStatementShow.playerStatementShow.updateExpText(exp, maxExpPerLevel[level]);
    }

    public override void growLevel(int l)
    {
        base.growLevel(l);
        GUIPlayerStatementShow.playerStatementShow.updateLevelText(level);
        GUIPlayerStatementShow.playerStatementShow.updateHpText(hp, maxHp[level]);
        GUIPlayerStatementShow.playerStatementShow.updateMpText(mp, maxMp[level]);
    }

    public void Refresh()
    {
        Awake();
        Start();
    }

    public void showInitStatement(object sender, BaseEventArgs e)
    {
        GUIPlayerStatementShow.playerStatementShow.updateHpText(hp, maxHp[level]);
        GUIPlayerStatementShow.playerStatementShow.updateMpText(mp, maxMp[level]);
        GUIPlayerStatementShow.playerStatementShow.updateExpText(exp, maxExpPerLevel[level]);
        GUIPlayerStatementShow.playerStatementShow.updateLevelText(level);
    }

    void OnDestroy()
    {
        Message.RemoveMessageHandle(new Message.LEVELISDONE(), showInitStatement);
    }
}
