﻿using UnityEngine;
using System.Collections;
using UnityTool.Libgame;

public class Level6Statement : LevelBaseStatement
{
    public GameObject redSphere;
    public GameObject blueSphere;

    public Vector3 redPosition, bluePosition;
    bool flag;

    // Use this for initialization
    protected new void Awake()
    {
        base.Awake();
        levelTitle = "交错之境 前章";
        levelIntroduction = "\n\t当你打败矛石部队，想要离开的时候，你遇上了七彩军团之间的红蓝内战。红方与蓝方是敌人，但是你同时是他们共同的敌人。\n\t作为红龙殿的传人，你该何去何从，又该如何顺利逃脱？\n\t胜利条件:剩余敌人数小于等于0\n\t失败条件:生命值小于等于0\n";
        info = "交错之境 前章\n\n\t胜利条件:剩余敌人数小于等于0\n\t失败条件:生命值小于等于0\n";
    }

    // Use this for initialization
    new void Start()
    {
        base.Start();

        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!flag && levelStatementIsDone)
        {
            if (enemiesNumber > 300)
            {
                flag = true;
                return;
            }
            else if (getEnemiesAlive() < 100) 
            {
                ObjectPool.Instantiate(redSphere, redPosition, Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform);

                ObjectPool.Instantiate(blueSphere, bluePosition, Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform);

                enemiesNumber += 2;
                Message.RaiseOneMessage<int>("AddEnemyAlive", this, 2);
                canCheckGame = true;
            }
        }
    }

    public override int checkGame()
    {
        if (getEnemiesAlive() <= 0)
        {
            return 1;
        }
        if (PlayerBaseStatement.playerBaseStatement.lifeRemain <= 0)
        {
            return -1;
        }
        return 0;
    }
}
