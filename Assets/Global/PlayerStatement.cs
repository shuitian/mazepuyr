using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatement : PlayerBaseStatement
{

    private HpShow hpShow;
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
        hpShow = GameObject.Find("hpText").GetComponent<HpShow>();
        hpShow.updateGUI(hp, maxHp);
        lifeRemain = maxLife;
        playerBaseStatement = GetComponent<PlayerStatement>();

        isPositionSet = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isPositionSet)
        {
            if (GameStatement.levelStatementIsDone)
            {
                transform.position = GameStatement.levelStatement.bornPosition;
                print(GameStatement.levelStatement.bornPosition);
                isPositionSet = true;
            }
        }
        if (!GameStatement.gameStatement.paused)
        {
            if (!isAlive())
            {
                loseLevel();
            }
        }
	}

    public override void loseHp(float losedHp)
    {
        //print("losedHp:" + losedHp);
        hp -= losedHp;
        if (hp <= 0)
        {
            hp = maxHp;
            lifeRemain--;
            if (!isAlive())
            {
                loseLevel();
            }
        }
        hpShow.updateGUI(hp, maxHp);
    }

    public override void getExp(float exp)
    {
        //print("exp:" + exp);
        this.exp += exp;
        if (exp > maxExpPerLevel[level-1] && level <= maxLevel)
        {
            exp = 0;
            level++;
        }
    }


    public override void loseLevel()
    {
        MsgPanel.msgPanel.showLose();
        MenuControl.menuControl.OnPause();
    }

    public override void passLevel()
    {
        MsgPanel.msgPanel.showWin();
        MenuControl.menuControl.OnPause();
    }

    public override void Refresh()
    {
        Start();
    }
}
