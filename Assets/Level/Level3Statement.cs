using UnityEngine;
using System.Collections;

public class Level3Statement : LevelBaseStatement
{

	// Use this for initialization
	void Start () {
        maxEnemiesNumber = 200;
        bornPosition = new Vector3(900, 2, 900);
        terrainMaxY = 500;
        info = " 第三关\n 胜利条件:杀死地图中央的BOSS\n 失败条件:生命值为0";
        //showInfo();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
