using UnityEngine;
using System.Collections;
using Regame;

public class Level7Statement : LevelBaseStatement
{
    public GameObject redSphere;
    public GameObject blueSphere;
    public GameObject orangeSphere;
    public Vector3 redPosition, bluePosition, orangePosition;
    bool flag;
    
    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
        levelTitle = "交错之境 中章";
        levelIntroduction = "\n\t你在逃脱过程中，被敌人发现，红蓝军团带来了橙色重甲兵团来消灭你。\n\t作为红龙殿的传人，你该如何击穿敌人的重甲，获取胜利？\n\t胜利条件:剩余敌人数小于等于0\n\t失败条件:生命值小于等于0\n";
        info = "交错之境 中章\n\n\t胜利条件:剩余敌人数小于等于0\n\t失败条件:生命值小于等于0\n";
    }

    // Use this for initialization
    void Start()
    {
        base.Start();

        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (!flag && GameStatement.levelStatementIsDone)
        {
            if (enemiesNumber > 400)
            {
                flag = true;
                return;
            }
            else if (GameStatement.gameStatement.getEnemiesAlive() < 100) 
            {
                GameObject clone;
                clone = ObjectPool.Instantiate(redSphere, redPosition, Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform) as GameObject;

                clone = ObjectPool.Instantiate(blueSphere, bluePosition, Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform) as GameObject;

                clone = ObjectPool.Instantiate(orangeSphere, orangePosition, Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform) as GameObject;

                enemiesNumber += 3;
                Message.RaiseOneMessage<int>("AddEnemyAlive", this, 3);
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
