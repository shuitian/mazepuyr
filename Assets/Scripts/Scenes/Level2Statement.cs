using UnityEngine;
using System.Collections;
using UnityTool.Libgame;

public class Level2Statement : LevelBaseStatement
{

    public GameObject enemySphere;
    public GameObject enemyCube;
    GameObject obj;
    bool flag;
    // Use this for initialization
    protected new void Awake()
    {
        base.Awake();
        levelTitle = "荒芜平原 中章";
        levelIntroduction = "\n\t白色先锋队的失利，遏制住了蓝龙大陆的侵略。但是，战斗并没有结束，白色先锋队带来了白色立方体军团来一雪前耻。作为红龙殿的传人，你做好了赶走敌人的准备了吗？\n\t胜利条件:剩余敌人数小于20\n\t失败条件:生命值小于等于0\n";
        info = "\t荒芜平原 中章\n\n\t胜利条件:剩余敌人数小于10\n\t失败条件:生命值小于等于0";
    }

    // Use this for initialization
    new void Start () {
        base.Start();

        baseTerrain.transform.Find("Up").position = new Vector3(1000, 500, 1000);

        flag = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!flag && LevelBaseStatement.levelStatementIsDone)
        {
            if (enemiesNumber >= maxEnemiesNumber)
            {
                flag = true;
                return;
            }
            else if (enemiesNumber < maxEnemiesNumber / 2)
            {
                obj = enemySphere;
            }
            else
            {
                obj = enemyCube;
            }
            ObjectPool.Instantiate(obj, new Vector3(terrainMaxX / 2, 1.5F, terrainMaxZ / 2), Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform);
            enemiesNumber++;
            Message.RaiseOneMessage<int>("AddEnemyAlive", this, 1);
            if (enemiesNumber > 30)
            {
                canCheckGame = true;
            }
        }
	}

    public override int checkGame()
    {
        if (getEnemiesAlive() < 10)
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
