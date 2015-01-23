using UnityEngine;
using System.Collections;
using System;

public class Level4Statement : LevelBaseStatement
{
    public GameObject bigSphere;
    public GameObject bigSphereChild;
    SkillCreateChild skillCreateChild;
    BaseStatement bigSphereStatement;
    public int maxChildNumber;
    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
        levelTitle = "尖牙山岭";
        levelIntroduction = "\n\t白色军团撤出了荒芜平原，退回到了尖牙山岭。由于尖牙山岭的地貌特征，白色军团装备上了简陋的飞行装置，白色军团的最后防线设置在了尖牙山谷中。\n\t作为红龙殿的传人，你做好了消灭白色军团的准备了吗？\n\t胜利条件:杀死地图的BOSS\n\t失败条件:生命值小于等于0\n";
        info = "\t尖牙山岭\n\n\t胜利条件:杀死地图中的BOSS\n\t失败条件:生命值小于等于0";

        Message.RegeditMessageHandle(new Message.LEVELISDONE(), BeginCreateEnemy);
    }

    // Use this for initialization
    void Start()
    {
        base.Start();
        baseTerrain.transform.Find("Up").position = new Vector3(1000, 300, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
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

    public void BeginCreateEnemy(object sender, BaseEventArgs e)
    {
        bigSphere = EnemyPool.Enemy(bigSphere, new Vector2(1000, 400), Quaternion.identity) as GameObject;

        bigSphereStatement = bigSphere.GetComponent<BaseStatement>();
        skillCreateChild = bigSphere.GetComponentInChildren<SkillCreateChild>();
        skillCreateChild.toBeCreated = bigSphereChild;
        skillCreateChild.maxNumber = maxChildNumber;

        GameStatement.beginGenereate = true;
    }

    void OnDestroy()
    {
        Message.RemoveMessageHandle(new Message.LEVELISDONE(), BeginCreateEnemy);
    }
}
