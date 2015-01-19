using UnityEngine;
using System.Collections;

public class Level1Statement : LevelBaseStatement
{
    bool flag;
    GameObject enemySphere;
    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
        levelTitle = "荒芜平原 前章";
        levelIntroduction = "\n\t荒芜平原，是一个一眼望不到尽头的地方，地处红龙大陆东北角。这里是战争前线，这里洒了太多的鲜血，这里有着太多的故事。今天，蓝龙大陆的敌人白色军团派出了白色先锋队，想要占领荒芜平原。作为红龙殿的传人，你做好了赶走敌人的准备了吗？\n\t胜利条件:剩余敌人数小于20\n\t失败条件:生命值小于等于0\n";
        info = "\t荒芜平原 前章\n\n\t胜利条件:剩余敌人数小于20\n\t失败条件:生命值小于等于0";

        maxEnemiesNumber = 150;
        bornPosition = new Vector3(1000, 5, 1000);

        baseTerrain = Resources.Load("Prefab/Terrain/BaseTerrain") as GameObject;
        FPC = Resources.Load("Prefab/FPC") as GameObject;
        canvasGUI = Resources.Load("GUI/Canvas/CanvasGUI") as GameObject;

        enemySphere = Resources.Load("Prefab/Enemy/白球") as GameObject;
        enemySphere.name = "球";
    }

	// Use this for initialization
	void Start () {
        base.Start();

        GameObject.Instantiate(canvasGUI, Vector3.zero, Quaternion.identity);

        GameObject.Instantiate(baseTerrain, Vector3.zero, Quaternion.identity);

        GameObject.Instantiate(FPC, GameStatement.levelStatement.bornPosition, Quaternion.identity);

        flag = false;
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
        if (!flag && GameStatement.levelStatementIsDone)
        {
            if (enemiesNumber >= GameStatement.levelStatement.maxEnemiesNumber)
            {
                flag = true;
                return;
            }
            GameObject clone = EnemyPool.Enemy(enemySphere, new Vector3(UnityEngine.Random.Range(GameStatement.levelStatement.terrainMinX + 1, GameStatement.levelStatement.terrainMaxX - 1), MyTerrainData.terrainData.GetHeight(GameStatement.levelStatement.terrainMaxX / 2, GameStatement.levelStatement.terrainMaxZ / 2) + enemySphere.transform.localScale.y / 2, UnityEngine.Random.Range(GameStatement.levelStatement.terrainMinZ + 1, GameStatement.levelStatement.terrainMaxZ - 1)), Quaternion.identity) as GameObject;
            enemiesNumber++;
            if (enemiesNumber > 30)
            {
                GameStatement.beginGenereate = true;
            }
            GameStatement.gameStatement.addEnemyAlive();
        }
	}

    public override int checkGame()
    {
        if (GameStatement.gameStatement.enemiesAlive <20)
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
