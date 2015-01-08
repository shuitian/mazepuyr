using UnityEngine;
using System.Collections;

public class Level1Statement : LevelBaseStatement
{
    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
        levelTitle = "荒芜平原 前章";
        levelIntroduction = "\n\t荒芜平原，是一个一眼望不到尽头的地方，地处红龙大陆东北角。这里是战争前线，这里洒了太多的鲜血，这里有着太多的故事。今天，蓝龙大陆的敌人白色军团派出了白色先锋队，想要占领荒芜平原。作为红龙殿的传人，你做好了赶走敌人的准备了吗？\n\t胜利条件:剩余敌人数小于20\n\t失败条件:生命值为0\n";
        info = "\t荒芜平原 前章\n\n\t胜利条件:剩余敌人数小于20\n\t失败条件:生命值为0";

        maxEnemiesNumber = 150;
        bornPosition = new Vector3(1000, 5, 1000);

        baseTerrain = Resources.Load("Prefab/Terrain/BaseTerrain") as GameObject;
        FPC = Resources.Load("Prefab/FPC") as GameObject;
        canvasGUI = Resources.Load("GUI/Canvas/CanvasGUI") as GameObject;
    }

	// Use this for initialization
	void Start () {
        base.Start();

        GameObject.Instantiate(canvasGUI, Vector3.zero, Quaternion.identity);

        GameObject.Instantiate(baseTerrain, Vector3.zero, Quaternion.identity);

        GameObject.Instantiate(FPC, GameStatement.levelStatement.bornPosition, Quaternion.identity);

        enemyGenerator.AddComponent<EnemySphereStatement>();
        enemyGenerator.AddComponent<Level1Action>();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
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

    public override LevelBaseStatement getLevelBaseStatement()
    {
        levelBaseStatement = gameObject.GetComponent<Level1Statement>();
        return levelBaseStatement;
    }

    public override void setLevelBaseStatement(LevelBaseStatement levelBaseStatement)
    {
        this.levelBaseStatement = levelBaseStatement;
    }
}
