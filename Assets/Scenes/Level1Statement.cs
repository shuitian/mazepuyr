using UnityEngine;
using System.Collections;
using Regame;

public class Level1Statement : LevelBaseStatement
{
    bool flag;
    public GameObject enemySphere;
    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
        levelTitle = "荒芜平原 前章";
        levelIntroduction = "\n\t荒芜平原，是一个一眼望不到尽头的地方，地处红龙大陆东北角。这里是战争前线，这里洒了太多的鲜血，这里有着太多的故事。今天，蓝龙大陆的敌人白色军团派出了白色先锋队，想要占领荒芜平原。作为红龙殿的传人，你做好了赶走敌人的准备了吗？\n\t胜利条件:剩余敌人数小于20\n\t失败条件:生命值小于等于0\n";
        info = "\t荒芜平原 前章\n\n\t胜利条件:剩余敌人数小于20\n\t失败条件:生命值小于等于0";
    }

	// Use this for initialization
	void Start () {
        base.Start();
        flag = false;
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
        if (!flag && GameStatement.levelStatementIsDone)
        {
            if (enemiesNumber >= maxEnemiesNumber)
            {
                flag = true;
                return;
            }
            Vector2 position = new Vector2(UnityEngine.Random.Range(terrainMinX / 2 + 1, terrainMaxX / 2 - 1) + (terrainMaxX - terrainMinX) / 4, UnityEngine.Random.Range(terrainMinZ / 2 + 1, terrainMaxZ / 2 - 1) + (terrainMaxZ - terrainMinZ) / 4);
            GameObject clone = ObjectPool.Instantiate(
                enemySphere,
                new Vector3(
                    position.x, 
                        (MyTerrainData.terrainData == null) ? 0 : (MyTerrainData.terrainData.GetHeight((int)position.x, (int)position.y)),
                            position.y), 
                Quaternion.identity, 
                GameStatement.gameStatement.enemyPoolTransform
            ) as GameObject;
            Message.RaiseOneMessage<int>("AddEnemyAlive", this, 1);
            enemiesNumber++;
            if (!GameStatement.beginGenereate && enemiesNumber > 30) 
            {
                GameStatement.beginGenereate = true;
            }
        }
	}

    public override int checkGame()
    {
        if (GameStatement.gameStatement.getEnemiesAlive() < 20)
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
