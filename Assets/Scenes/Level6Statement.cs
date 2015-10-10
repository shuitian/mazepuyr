using UnityEngine;
using System.Collections;
using Regame;

public class Level6Statement : LevelBaseStatement
{
    public GameObject redSphere;
    public GameObject blueSphere;

    public Vector3 redPosition, bluePosition;
    bool flag;
    
    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
        levelTitle = "交错之境 前章";
        levelIntroduction = "\n\t当你打败矛石部队，想要离开的时候，你遇上了七彩军团之间的红蓝内战。红方与蓝方是敌人，但是你同时是他们共同的敌人。\n\t作为红龙殿的传人，你该何去何从，又该如何顺利逃脱？\n\t胜利条件:剩余敌人数小于等于0\n\t失败条件:生命值小于等于0\n";
        info = "交错之境 前章\n\n\t胜利条件:剩余敌人数小于等于0\n\t失败条件:生命值小于等于0\n";
    }

    // Use this for initialization
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (!flag && GameStatement.levelStatementIsDone)
        {
            if (enemiesNumber > 300)
            {
                flag = true;
                return;
            }
            else if (GameStatement.gameStatement.getEnemiesAlive() < 100) 
            {
                GameObject clone;
                clone = ObjectPool.Instantiate(redSphere, redPosition, Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform) as GameObject;

                clone = ObjectPool.Instantiate(blueSphere, bluePosition, Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform) as GameObject;

                enemiesNumber += 2;
                Message.RaiseOneMessage<int>("AddEnemyAlive", this, 2);
                GameStatement.beginGenereate = true;
            }
        }
    }

    public override int checkGame()
    {
        if (GameStatement.gameStatement.getEnemiesAlive() <= 0)
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
