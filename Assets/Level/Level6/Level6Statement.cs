using UnityEngine;
using System.Collections;

public class Level6Statement : LevelBaseStatement
{
    public GameObject enemyRed;
    public GameObject enemyBlue;
    GameObject redSphere;
    GameObject blueSphere;

    Material redDiffuse = Resources.Load("GUI/Materials/Red") as Material;
    Material blueDiffuse = Resources.Load("GUI/Materials/Blue") as Material;
    Vector3 p1, p2;
    bool flag;
    int step;
    int origin;

    
    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
        levelTitle = "交错之境";
        levelIntroduction = "\n\t当你打败矛石部队，想要离开的时候，你遇上了七彩军团之间的红蓝内战。红方与蓝方是敌人，但是你同时是他们共同的敌人。\n\t作为红龙殿的传人，你该何去何从，又该如何顺利逃脱？\n\t胜利条件:剩余敌人数小于等于0\n\t失败条件:生命值小于等于0\n";
        info = "交错之境\n\n\t胜利条件:剩余敌人数小于等于0\n\t失败条件:生命值小于等于0\n";

        bornPosition = new Vector3(1000, 10, 1000);
        maxEnemiesNumber = 300;

        baseTerrain = Resources.Load("Prefab/Terrain/Terrain2") as GameObject;
        FPC = Resources.Load("Prefab/FPC") as GameObject;
        canvasGUI = Resources.Load("GUI/Canvas/CanvasGUI") as GameObject;
        redSphere = Resources.Load("Prefab/Enemy/红球") as GameObject;
        blueSphere = Resources.Load("Prefab/Enemy/蓝球") as GameObject;
    }

    // Use this for initialization
    void Start()
    {
        base.Start();

        GameObject.Instantiate(canvasGUI, Vector3.zero, Quaternion.identity);

        GameObject terrain = GameObject.Instantiate(baseTerrain, Vector3.zero, Quaternion.identity) as GameObject;
        //terrain.transform.Find("Up").position = new Vector3(1000, 300, 1000);
        //terrain.transform.Find("West").position = new Vector3(700, 500, 1000);
        //terrain.transform.Find("East").position = new Vector3(1300, 500, 1000);
        //terrain.transform.Find("North").position = new Vector3(1000, 500, 1300);
        //terrain.transform.Find("South").position = new Vector3(1000, 500, 700);
        //terrainMaxX = 1300;
        //terrainMinX = 700;
        //terrainMaxY = 300;
        //terrainMaxZ = 1300;
        //terrainMinZ = 700;

        GameObject.Instantiate(FPC, GameStatement.levelStatement.bornPosition, Quaternion.identity);

        flag = false;
        origin = 800;
        step = 15;
        p1 = new Vector3(50, 50, origin);
        p2 = new Vector3(50, 50, 2000 - origin);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (!flag && GameStatement.levelStatementIsDone)
        {
            if (p1.x >= 2000)
            {
                flag = true;
                return;
            }
            else
            {
                GameObject clone;
                clone = EnemyPool.Enemy(redSphere, p1, Quaternion.identity) as GameObject;
                p1 += new Vector3(step, 0, 0);

                clone = EnemyPool.Enemy(blueSphere, p2, Quaternion.identity) as GameObject;
                p2 += new Vector3(step, 0, 0);

                enemiesNumber += 2;
                GameStatement.beginGenereate = true;
                GameStatement.gameStatement.addEnemyAlive(2);
            }
        }
    }

    public override int checkGame()
    {
        if (GameStatement.gameStatement.enemiesAlive <= 0)
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
