using UnityEngine;
using System.Collections;
using Regame;

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
        levelIntroduction = "\n\t你的所作所为激怒了敌人，白、红、蓝、橙、青、黄以及新出现的绿色军团来一起试一试你的斤两\n\t作为红龙殿的传人，你做好浴血奋战的准备了吗？\n\t胜利条件:剩余敌人数小于等于0\n\t失败条件:生命值小于等于0\n";
        info = "交错之境 后章\n\n\t胜利条件:剩余敌人数小于5\n\t失败条件:生命值小于等于0\n";
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
        if (!flag && levelStatementIsDone)
        {
            if (enemiesNumber > 480)
            {
                flag = true;
                return;
            }
            else if (getEnemiesAlive() < 75) 
            {
                ObjectPool.Instantiate(whiteSphere, whitePosition, Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform);

                ObjectPool.Instantiate(yellowSphere, yellowPosition, Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform);

                ObjectPool.Instantiate(cyanSphere, cyanPosition, Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform);

                ObjectPool.Instantiate(redSphere, redPosition, Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform);

                ObjectPool.Instantiate(blueSphere, bluePosition, Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform);

                ObjectPool.Instantiate(orangeSphere, orangePosition, Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform);

                ObjectPool.Instantiate(greenSphere, greenPosition, Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform);
                enemiesNumber += 7;
                Message.RaiseOneMessage<int>("AddEnemyAlive", this, 7);
                canCheckGame = true;
            }
        }
    }

    public override int checkGame()
    {
        if (getEnemiesAlive() < 5)
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
