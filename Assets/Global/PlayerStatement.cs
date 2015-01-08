using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerStatement : PlayerBaseStatement
{
    private bool isPositionSet;
	// Use this for initialization
    protected void Awake()
    {
        base.Awake();
        deadExp = 100;
        playerBaseStatement = GetComponent<PlayerStatement>();
        player = gameObject;
        isPositionSet = false;
	}

    protected void Start()
    {
        base.Start();
        Message.RegeditMessageHandle(new Message.LEVELISDONE(), showInitStatement);
    }
	
	// Update is called once per frame
	void Update () {
        if (!isPositionSet)
        {
            if (GameStatement.levelStatementIsDone)
            {
                transform.position = GameStatement.levelStatement.bornPosition;
                isPositionSet = true;
            }
            else
            {
                return;
            }
        }
        base.Update();
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

    public override void getExp(BaseStatement expFrom, float e)
    {
        base.getExp(expFrom, e);
        GUIPlayerStatementShow.playerStatementShow.updateLevelText(level);
        GUIPlayerStatementShow.playerStatementShow.updateExpText(exp, maxExpPerLevel[level]);
        GUIPlayerStatementShow.playerStatementShow.updateHpText(hp, maxHp[level]);
        GUIPlayerStatementShow.playerStatementShow.updateMpText(mp, maxMp[level]);
    }

    public override void Refresh()
    {
        Awake();
        Start();
    }

    public void showInitStatement(object sender, BaseEventArgs e)
    {
        try
        {
            GUIPlayerStatementShow.playerStatementShow.updateHpText(hp, maxHp[level]);
            GUIPlayerStatementShow.playerStatementShow.updateMpText(mp, maxMp[level]);
            GUIPlayerStatementShow.playerStatementShow.updateExpText(exp, maxExpPerLevel[level]);
            GUIPlayerStatementShow.playerStatementShow.updateLevelText(level);
        }
        catch (Exception e1)
        {
            Message.RemoveMessageHandle(new Message.LEVELISDONE(), showInitStatement);
        }
    }
}
