﻿using UnityEngine;
using System.Collections;

public class Level4Statement : LevelBaseStatement
{

    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
        levelTitle = "尖牙山岭";
        levelIntroduction = "\n\t白色军团撤出了荒芜平原，退回到了尖牙山岭。由于尖牙山岭的地貌特征，白色军团装备上了简陋的飞行装置，白色军团的最后防线设置在了尖牙山谷中。\n\t作为红龙殿的传人，你做好了消灭白色军团的准备了吗？\n\t胜利条件:杀死地图的BOSS\n\t失败条件:生命值为0\n";
        info = "\t尖牙山岭\n\n\t胜利条件:杀死地图中的BOSS\n\t失败条件:生命值为0";

        bornPosition = new Vector3(990, 22, 992);

        baseTerrain = Resources.Load("Prefab/Terrain/Terrain1") as GameObject;
        FPC = Resources.Load("Prefab/FPC") as GameObject;
        canvasGUI = Resources.Load("GUI/Canvas/CanvasGUI") as GameObject;
    }

    // Use this for initialization
    void Start()
    {
        base.Start();

        GameObject.Instantiate(canvasGUI, Vector3.zero, Quaternion.identity);

        GameObject terrain = GameObject.Instantiate(baseTerrain, Vector3.zero, Quaternion.identity) as GameObject;
        terrain.transform.Find("Up").position = new Vector3(1000, 300, 1000);
        terrainMaxY = 300;

        GameObject.Instantiate(FPC, GameStatement.levelStatement.bornPosition, Quaternion.identity);

        enemyGenerator.AddComponent<EnemyBigSphereStatement>();
        enemyGenerator.AddComponent<Level4Action>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override int checkGame()
    {
        if (Level4Action.bigSphere == null)
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