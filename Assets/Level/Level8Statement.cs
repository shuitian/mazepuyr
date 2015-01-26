using UnityEngine;
using System.Collections;

public class Level8Statement : LevelBaseStatement
{
    public GameObject whiteSphere;
    public GameObject yellowSphere;
    public GameObject cyanSphere;
    public GameObject redSphere;
    public GameObject blueSphere;
    public GameObject orangeSphere;
    public GameObject greenSphere;
    public Vector3 whitePosition, yellowPosition, cyanPosition, redPosition, bluePosition, orangePosition, greenPosition;
    bool flag;
    
    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
        levelTitle = "交错之境 后章";
        levelIntroduction = "\n\t你在逃脱过程中，被敌人发现，红蓝军团带来了橙色重甲兵团来消灭你。\n\t作为红龙殿的传人，你该如何击穿敌人的重甲，获取胜利？\n\t胜利条件:剩余敌人数小于等于0\n\t失败条件:生命值小于等于0\n";
        info = "交错之境 后章\n\n\t胜利条件:剩余敌人数小于等于0\n\t失败条件:生命值小于等于0\n";
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
            if (enemiesNumber > 500)
            {
                flag = true;
                return;
            }
            else if (GameStatement.gameStatement.getEnemiesAlive() < 80) 
            {
                GameObject clone;

                clone = EnemyPool.Enemy(whiteSphere, whitePosition, Quaternion.identity) as GameObject;

                clone = EnemyPool.Enemy(yellowSphere, yellowPosition, Quaternion.identity) as GameObject;

                clone = EnemyPool.Enemy(cyanSphere, cyanPosition, Quaternion.identity) as GameObject;

                clone = EnemyPool.Enemy(redSphere, redPosition, Quaternion.identity) as GameObject;

                clone = EnemyPool.Enemy(blueSphere, bluePosition, Quaternion.identity) as GameObject;

                clone = EnemyPool.Enemy(orangeSphere, orangePosition, Quaternion.identity) as GameObject;

                clone = EnemyPool.Enemy(greenSphere, greenPosition, Quaternion.identity) as GameObject;
                enemiesNumber += 7;
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
