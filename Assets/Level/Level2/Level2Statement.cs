using UnityEngine;
using System.Collections;

public class Level2Statement : LevelBaseStatement
{

    public GameObject enemySphere;
    public GameObject enemyCube;
    GameObject obj;
    bool flag;
    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
        levelTitle = "荒芜平原 中章";
        levelIntroduction = "\n\t白色先锋队的失利，遏制住了蓝龙大陆的侵略。但是，战斗并没有结束，白色先锋队带来了白色立方体军团来一雪前耻。作为红龙殿的传人，你做好了赶走敌人的准备了吗？\n\t胜利条件:剩余敌人数小于20\n\t失败条件:生命值小于等于0\n";
        info = "\t荒芜平原 中章\n\n\t胜利条件:剩余敌人数小于20\n\t失败条件:生命值小于等于0";

        maxEnemiesNumber = 250;
        bornPosition = new Vector3(1000, 5, 1);
        
        baseTerrain = Resources.Load("Prefab/Terrain/BaseTerrain") as GameObject;
        FPC = Resources.Load("Prefab/FPC") as GameObject;
        canvasGUI = Resources.Load("GUI/Canvas/CanvasGUI") as GameObject;

        enemySphere = Resources.Load("Prefab/Enemy/EnemySphere") as GameObject;
        enemyCube = Resources.Load("Prefab/Enemy/EnemyCube") as GameObject;
    }

	// Use this for initialization
	void Start () {
        base.Start();
        
        GameObject.Instantiate(canvasGUI, Vector3.zero, Quaternion.identity);

        GameObject terrain =  GameObject.Instantiate(baseTerrain, Vector3.zero, Quaternion.identity) as GameObject;
        terrain.transform.Find("Up").position = new Vector3(1000, 500, 1000);
        terrainMaxY = 500;

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
            else if (enemiesNumber < GameStatement.levelStatement.maxEnemiesNumber / 2)
            {
                obj = enemySphere;

            }
            else
            {
                obj = enemyCube;

            }
            GameObject clone = Instantiate(obj, new Vector3(GameStatement.levelStatement.terrainMaxX / 2, 1, GameStatement.levelStatement.terrainMaxZ / 2), new Quaternion(0, 0, 0, 0)) as GameObject;
            clone.name = obj.name + (enemiesNumber + 1);
            clone.transform.parent = enemyGenerator.transform;
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
        if (GameStatement.gameStatement.enemiesAlive < 20)
        {
            return 1;
        }
        if (PlayerBaseStatement.playerBaseStatement.lifeRemain <= 0)
        {
            return -1;
        }
        return 0;
    }

    //public override LevelBaseStatement getLevelBaseStatement()
    //{
    //    levelBaseStatement = gameObject.GetComponent<Level2Statement>();
    //    return levelBaseStatement;
    //}

    //public override void setLevelBaseStatement(LevelBaseStatement levelBaseStatement)
    //{
    //    this.levelBaseStatement = levelBaseStatement;
    //}
}
