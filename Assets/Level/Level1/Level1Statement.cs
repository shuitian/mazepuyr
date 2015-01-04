using UnityEngine;
using System.Collections;

public class Level1Statement : LevelBaseStatement
{
	// Use this for initialization
	void Start () {
        base.Start();
        maxEnemiesNumber = 100;
        bornPosition = new Vector3(1000, 1, 1000);
        info = " 第一关\n 胜利条件:剩余敌人数为0\n 失败条件:生命值为0";

        baseTerrain = Resources.Load("Prefab/Terrain/BaseTerrain") as GameObject;
        FPC = Resources.Load("Prefab/FPC") as GameObject;
        canvasGUI = Resources.Load("GUI/Canvas/CanvasGUI") as GameObject;
        GameObject.Instantiate(canvasGUI, Vector3.zero, Quaternion.identity);
        GameObject.Instantiate(baseTerrain, Vector3.zero, Quaternion.identity);
        GameObject.Instantiate(FPC, GameStatement.levelStatement.bornPosition, Quaternion.identity);

        enemyGenerator.AddComponent<SphereEnemyStatement>();
        enemyGenerator.AddComponent<CreateLevel1Enemies>();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}

    public override int checkGame()
    {
        if (GameStatement.gameStatement.enemiesAlive <=0)
        {
            return 1;
        }
        if (PlayerBaseStatement.playerBaseStatement.hp <= 0)
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
