using UnityEngine;
using System.Collections;

public class Level2Statement : LevelBaseStatement
{

	// Use this for initialization
	void Start () {
        maxEnemiesNumber = 200;
        bornPosition = new Vector3(1000, 1, 1);
        info = " 第二关\n 胜利条件:剩余敌人数为0\n 失败条件:生命值为0";
        //showInfo();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override LevelBaseStatement getLevelBaseStatement()
    {
        levelBaseStatement = gameObject.GetComponent<Level2Statement>();
        return levelBaseStatement;
    }

    public override void setLevelBaseStatement(LevelBaseStatement levelBaseStatement)
    {
        this.levelBaseStatement = levelBaseStatement;
    }
}
