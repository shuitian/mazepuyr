using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerStatement : PlayerBaseStatement
{
    private bool isPositionSet;
	// Use this for initialization
	void Start () {
        maxHp = 100F;
        hp = maxHp;
        maxMp = 100F;
        mp = maxMp;
        exp = 0;
        maxLife = 1;
        lifeRemain = maxLife;
        level = 1;
        maxLevel = 10;
        PlayerStatementShow.playerStatementShow.updateHpText(hp, maxHp);
        PlayerStatementShow.playerStatementShow.updateMpText(mp, maxMp);
        PlayerStatementShow.playerStatementShow.updateExpText(exp, maxExpPerLevel[level - 1]);
        PlayerStatementShow.playerStatementShow.updateLevelText(level);
        lifeRemain = maxLife;
        playerBaseStatement = GetComponent<PlayerStatement>();
        //print(playerBaseStatement);
        player = gameObject;
        isPositionSet = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isPositionSet)
        {
            if (GameStatement.levelStatementIsDone)
            {
                transform.position = GameStatement.levelStatement.bornPosition;
                //print(GameStatement.levelStatement.bornPosition);
                isPositionSet = true;
            }
        }
        try
        {
            if (!GameStatement.gameStatement.paused)
            {
                if (!isAlive())
                {
                    loseLevel();
                }
            }
        }
        catch (Exception e)
        {
        }
	}

    public override void loseHp(float losedHp)
    {
        //print("losedHp:" + losedHp);
        hp -= losedHp;
        if (hp <= 0)
        {
            lifeRemain--;
            if(lifeRemain>0)
            {
                hp = maxHp;
            }
            if (!isAlive())
            {
                loseLevel();
            }
        }
        //print(transform.position);
        PlayerStatementShow.playerStatementShow.updateHpText(hp, maxHp);
    }

    public override void getExp(float e)
    {
        exp += e;
        if (exp > maxExpPerLevel[level - 1] && level <= maxLevel)
        {
            exp = 0;
            level++;
            PlayerStatementShow.playerStatementShow.updateLevelText(level);
        }
        PlayerStatementShow.playerStatementShow.updateExpText(exp, maxExpPerLevel[level - 1]);
    }


    //public override void loseLevel()
    //{
    //    MsgPanel.msgPanel.showLose();
    //    MenuControl.menuControl.OnPause();
    //}

    //public override void passLevel()
    //{
    //    MsgPanel.msgPanel.showWin();
    //    MenuControl.menuControl.OnPause();
    //}

    public override void Refresh()
    {
        Start();
    }
}
