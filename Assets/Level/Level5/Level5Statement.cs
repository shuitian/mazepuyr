using UnityEngine;
using System.Collections;

public class Level5Statement : LevelBaseStatement
{

    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
        levelTitle = "矛石领地";
        levelIntroduction = "\n\t白色军团被彻底打败，只余下一小部分逃回去，你在追击过程中，陷入了七彩军团的矛石部队。矛石部队身披黄袍，手中的黄色长矛是他们远距离打击的利器\n\t作为红龙殿的传人，你做好了向敌人展示力量的准备了吗？\n\t胜利条件:剩余敌人数为0\n\t失败条件:生命值为0\n";
        info = "\t矛石领地\n\n\t胜利条件:剩余敌人数为0\n\t失败条件:生命值为0";

        bornPosition = new Vector3(1000, 10, 1000);
        maxEnemiesNumber = 300;

        baseTerrain = Resources.Load("Prefab/Terrain/Terrain2") as GameObject;
        FPC = Resources.Load("Prefab/FPC") as GameObject;
        canvasGUI = Resources.Load("GUI/Canvas/CanvasGUI") as GameObject;
    }

    // Use this for initialization
    void Start()
    {
        base.Start();

        GameObject.Instantiate(canvasGUI, Vector3.zero, Quaternion.identity);

        GameObject terrain = GameObject.Instantiate(baseTerrain, Vector3.zero, Quaternion.identity) as GameObject;

        GameObject.Instantiate(FPC, GameStatement.levelStatement.bornPosition, Quaternion.identity);

        //enemyGenerator.AddComponent<EnemySphereStatement>();
        //enemyGenerator.AddComponent<EnemyFlyingSphereStatement>();
        enemyGenerator.AddComponent<EnemyYellowSphereStatement>();
        enemyGenerator.AddComponent<Level5Action>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override int checkGame()
    {
        if (GameStatement.gameStatement.enemiesAlive <=0 )
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
