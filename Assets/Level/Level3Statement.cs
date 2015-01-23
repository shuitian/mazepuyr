using UnityEngine;
using System.Collections;
using System;

public class Level3Statement : LevelBaseStatement
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
        levelTitle = "荒芜平原 后章";
        levelIntroduction = "\n\t立方体军团同样大败而归，蓝龙军团气势大降，在荒芜平原的势力范围正在逐渐缩小，再没有一场胜利，白色军团可能就要撤出荒芜平原了。为了挽回败局，白色军团的军团长出现了。作为红龙殿的传人，你做好了背水一战的准备了吗？\n\t胜利条件:杀死地图中的BOSS\n\t失败条件:生命值小于等于0\n";
        info = "\t荒芜平原 后章\n\n\t胜利条件:杀死地图中的BOSS\n\t失败条件:生命值小于等于0";

        Message.RegeditMessageHandle(new Message.LEVELISDONE(), BeginCreateEnemy);
    }

	// Use this for initialization
	void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
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
        bigSphere = EnemyPool.Enemy(bigSphere, new Vector2(terrainMaxX / 2, terrainMaxZ / 2), Quaternion.identity) as GameObject;

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
