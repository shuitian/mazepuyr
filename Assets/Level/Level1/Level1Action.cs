using UnityEngine;
using System.Collections;
using System;

public class Level1Action : LevelBaseAction
{

    public EnemySphereStatement enemySphereStatement;
    bool flag;
    GameObject obj;
    // Use this for initialization
    void Awake()
    {
        //Message.RegeditMessageHandle(new Message.LEVELISDONE(), BeginCreateEnemy);
        enemySphereStatement = GetComponent<EnemySphereStatement>();
	}
    void Start()
    {
        base.Start();
        flag = false;
    }
        
	// Update is called once per frame
	void Update () {
        if (!flag && GameStatement.levelStatementIsDone)
        {
            if (enemiesNumber >= GameStatement.levelStatement.maxEnemiesNumber)
            {
                flag = true;
                return;
            }
            if (obj == null)
            {
                obj = enemySphereStatement.getObj();
            }
            GameObject clone = Instantiate(obj, new Vector3(UnityEngine.Random.Range(GameStatement.levelStatement.terrainMinX + 1, GameStatement.levelStatement.terrainMaxX - 1), MyTerrainData.terrainData.GetHeight(GameStatement.levelStatement.terrainMaxX / 2, GameStatement.levelStatement.terrainMaxZ / 2) + enemySphereStatement.getObj().transform.localScale.y / 2, UnityEngine.Random.Range(GameStatement.levelStatement.terrainMinZ + 1, GameStatement.levelStatement.terrainMaxZ - 1)), Quaternion.identity) as GameObject;
            clone.name = obj.name + (enemiesNumber + 1);
            clone.transform.parent = transform;
            enemiesNumber++;
            if (enemiesNumber > 30)
            {
                GameStatement.beginGenereate = true;
            }
            GameStatement.gameStatement.enemiesAlive++;
            GUIEnemyNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
        }
	}

    //public void BeginCreateEnemy(object sender, BaseEventArgs e)
    //{
    //    try
    //    {
    //        if (gameObject)
    //        {
    //            while (enemiesNumber < GameStatement.levelStatement.maxEnemiesNumber)
    //            {
    //                GameObject clone = Instantiate(enemySphereStatement.getObj(), new Vector3(UnityEngine.Random.Range(GameStatement.levelStatement.terrainMinX + 1, GameStatement.levelStatement.terrainMaxX - 1), MyTerrainData.terrainData.GetHeight(GameStatement.levelStatement.terrainMaxX / 2, GameStatement.levelStatement.terrainMaxZ / 2) + enemySphereStatement.getObj().transform.localScale.y / 2, UnityEngine.Random.Range(GameStatement.levelStatement.terrainMinZ + 1, GameStatement.levelStatement.terrainMaxZ - 1)), Quaternion.identity) as GameObject;
    //                clone.name = "EnemySphere" + (enemiesNumber + 1);
    //                clone.transform.parent = transform;
    //                enemiesNumber++;
    //                GameStatement.gameStatement.enemiesAlive++;
    //                GameStatement.beginGenereate = true;
    //                GUIEnemyNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
    //            }
    //        }
    //        else
    //        {
    //            Message.RemoveMessageHandle(new Message.LEVELISDONE(), BeginCreateEnemy);
    //        }
    //    }
    //    catch (Exception e1)
    //    {
    //        Message.RemoveMessageHandle(new Message.LEVELISDONE(), BeginCreateEnemy);
    //    }
    //}
}
