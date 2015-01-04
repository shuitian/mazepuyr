using UnityEngine;
using System.Collections;

public class Level3Statement : LevelBaseStatement
{

	// Use this for initialization
	void Start () {
        base.Start();
        //maxEnemiesNumber = 200;
        bornPosition = new Vector3(900, 2, 900);
        terrainMaxY = 500;
        info = " 第三关\n 胜利条件:杀死地图中央的BOSS\n 失败条件:生命值为0";

        baseTerrain = Resources.Load("Prefab/Terrain/BaseTerrain") as GameObject;
        FPC = Resources.Load("Prefab/FPC") as GameObject;
        canvasGUI = Resources.Load("GUI/Canvas/CanvasGUI") as GameObject;
        GameObject.Instantiate(canvasGUI, Vector3.zero, Quaternion.identity);
        GameObject.Instantiate(baseTerrain, Vector3.zero, Quaternion.identity);
        GameObject.Instantiate(FPC, GameStatement.levelStatement.bornPosition, Quaternion.identity);

        enemyGenerator.AddComponent<BigSphereStatement>();
        enemyGenerator.AddComponent<CreateLevel3Enemies>();
        //showInfo();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}

    public override int checkGame()
    {
        if (CreateLevel3Enemies.bigSphere == null)
        {
            return 1;
        }
        if (PlayerBaseStatement.playerBaseStatement.hp <= 0)
        {
            return -1;
        }
        return 0;
    }
}
