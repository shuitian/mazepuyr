using UnityEngine;
using System.Collections;

public class Level1Statement : LevelBaseStatement
{
	// Use this for initialization
	void Start () {
        maxEnemiesNumber = 100;
        bornPosition = new Vector3(1000, 1, 1000);
	}
	
	// Update is called once per frame
	void Update () {
	
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
