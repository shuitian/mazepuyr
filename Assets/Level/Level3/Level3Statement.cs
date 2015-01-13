using UnityEngine;
using System.Collections;
using System;

public class Level3Statement : LevelBaseStatement
{
    public GameObject bigSphere;
    GameObject obj;
    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
        
        levelTitle = "荒芜平原 后章";
        levelIntroduction = "\n\t立方体军团同样大败而归，蓝龙军团气势大降，在荒芜平原的势力范围正在逐渐缩小，再没有一场胜利，白色军团可能就要撤出荒芜平原了。为了挽回败局，白色军团的军团长出现了。作为红龙殿的传人，你做好了背水一战的准备了吗？\n\t胜利条件:杀死地图中的BOSS\n\t失败条件:生命值小于等于0\n";
        info = "\t荒芜平原 后章\n\n\t胜利条件:杀死地图中的BOSS\n\t失败条件:生命值小于等于0";

        bornPosition = new Vector3(950, 5, 950);

        baseTerrain = Resources.Load("Prefab/Terrain/BaseTerrain") as GameObject;
        FPC = Resources.Load("Prefab/FPC") as GameObject;
        canvasGUI = Resources.Load("GUI/Canvas/CanvasGUI") as GameObject;
        obj = Resources.Load("Prefab/Enemy/EnemyBigSphere") as GameObject;

        Message.RegeditMessageHandle(new Message.LEVELISDONE(), BeginCreateEnemy);
    }

	// Use this for initialization
	void Start () {
        base.Start();
        
        GameObject.Instantiate(canvasGUI, Vector3.zero, Quaternion.identity);

        GameObject.Instantiate(baseTerrain, Vector3.zero, Quaternion.identity);

        GameObject.Instantiate(FPC, GameStatement.levelStatement.bornPosition, Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}

    public override int checkGame()
    {
        if (bigSphere == null)
        {
            return 1;
        }
        if (PlayerBaseStatement.playerBaseStatement.lifeRemain <= 0)
        {
            return -1;
        }
        return 0;
    }

    public void BeginCreateEnemy(object sender, BaseEventArgs e)
    {
        try
        {
            if (gameObject)
            {
                bigSphere = Instantiate(obj, new Vector3(GameStatement.levelStatement.terrainMaxX / 2, MyTerrainData.terrainData.GetHeight(GameStatement.levelStatement.terrainMaxX / 2, GameStatement.levelStatement.terrainMaxZ / 2) + obj.transform.localScale.y / 2, GameStatement.levelStatement.terrainMaxZ / 2), Quaternion.identity) as GameObject;
                bigSphere.GetComponentInChildren<EnemyBigSphereAI>().setCreatedObject("Prefab/Enemy/EnemySphere");
                bigSphere.GetComponentInChildren<EnemyBigSphereAI>().setMaxNumber(150);
                bigSphere.name = obj.name;
                bigSphere.transform.parent = enemyGenerator.transform;

                GameStatement.gameStatement.addEnemyAlive();
                GameStatement.beginGenereate = true;
            }
            else
            {
                Message.RemoveMessageHandle(new Message.LEVELISDONE(), BeginCreateEnemy);
            }
        }
        catch (Exception e1)
        {
            Message.RemoveMessageHandle(new Message.LEVELISDONE(), BeginCreateEnemy);
        }
    }
}
