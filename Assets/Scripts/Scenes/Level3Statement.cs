using UnityEngine;
using System.Collections;
using System;
using UnityTool.Libgame;

public class Level3Statement : LevelBaseStatement
{
    public GameObject bigSphere;
    public GameObject bigSphereChild;
    SkillCreateChild skillCreateChild;
    BaseStatement bigSphereStatement;
    public int maxChildNumber;
    // Use this for initialization
    protected new void Awake()
    {
        base.Awake();
        levelTitle = "荒芜平原 后章";
        levelIntroduction = "\n\t立方体军团同样大败而归，蓝龙军团气势大降，在荒芜平原的势力范围正在逐渐缩小，再没有一场胜利，白色军团可能就要撤出荒芜平原了。为了挽回败局，白色军团的军团长出现了。作为红龙殿的传人，你做好了背水一战的准备了吗？\n\t胜利条件:杀死地图中的BOSS\n\t失败条件:生命值小于等于0\n";
        info = "\t荒芜平原 后章\n\n\t胜利条件:杀死地图中的BOSS\n\t失败条件:生命值小于等于0";

        Message.RegeditMessageHandle<string>("LevelIsDone", BeginCreateEnemy);
    }

    void OnDestroy()
    {
        Message.UnregeditMessageHandle<string>("LevelIsDone", BeginCreateEnemy);
    }

    void BeginCreateEnemy(string messageName, object sender, string empty)
    {
        Vector2 position = new Vector2(terrainMaxX / 2, terrainMaxZ / 2);
        bigSphere = ObjectPool.Instantiate(
            bigSphere,
            new Vector3(
                position.x,
                    (MyTerrainData.terrainData == null) ? 0 : (MyTerrainData.terrainData.GetHeight((int)position.x, (int)position.y)),
                        position.y),
            Quaternion.identity,
            GameStatement.gameStatement.enemyPoolTransform
        ) as GameObject;
        Message.RaiseOneMessage<int>("AddEnemyAlive", this, 1);
        bigSphereStatement = bigSphere.GetComponent<BaseStatement>();
        skillCreateChild = bigSphere.GetComponentInChildren<SkillCreateChild>();
        skillCreateChild.toBeCreated = bigSphereChild;
        skillCreateChild.maxNumber = maxChildNumber;

        canCheckGame = true;
    }

    public override int checkGame()
    {
        if (!bigSphereStatement || bigSphereStatement.isDead)
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
