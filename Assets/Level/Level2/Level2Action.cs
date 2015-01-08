using UnityEngine;
using System.Collections;
using System;

public class Level2Action : LevelBaseAction
{

    public EnemySphereStatement enemySphereStatement;
    public EnemyCubeStatement enemyCubeStatement;
    bool flag;
    GameObject obj;
    // Use this for initialization
    void Awake()
    {
        //Message.RegeditMessageHandle(new Message.LEVELISDONE(), BeginCreateEnemy);
        enemySphereStatement = GetComponent<EnemySphereStatement>();
        enemyCubeStatement = GetComponent<EnemyCubeStatement>();
    }
    void Start()
    {
        base.Start();
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!flag && GameStatement.levelStatementIsDone)
        {
            if (enemiesNumber >= GameStatement.levelStatement.maxEnemiesNumber)
            {
                flag = true;
                return;
            }
            else if (enemiesNumber < GameStatement.levelStatement.maxEnemiesNumber / 2)
            {
                obj = enemySphereStatement.getObj();
                
            }
            else
            {
                obj = enemyCubeStatement.getObj();
                
            }
            GameObject clone = Instantiate(obj, new Vector3(GameStatement.levelStatement.terrainMaxX / 2, 1, GameStatement.levelStatement.terrainMaxZ / 2), new Quaternion(0, 0, 0, 0)) as GameObject;
            clone.name = obj.name + (enemiesNumber + 1);
            clone.transform.parent = gameObject.transform;
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
    //                if (enemiesNumber < GameStatement.levelStatement.maxEnemiesNumber / 2)
    //                {
    //                    GameObject clone = Instantiate(enemySphereStatement.getObj(), new Vector3(GameStatement.levelStatement.terrainMaxX / 2, MyTerrainData.terrainData.GetHeight(GameStatement.levelStatement.terrainMaxX / 2, GameStatement.levelStatement.terrainMaxZ / 2) /*+ sphereEnemyStatement.getObj().transform.localScale.y/2*/, GameStatement.levelStatement.terrainMaxZ / 2), Quaternion.identity) as GameObject;
    //                    clone.name = "EnemySphere" + (enemiesNumber + 1);
    //                    clone.transform.parent = gameObject.transform;
    //                    enemiesNumber++;
    //                    GameStatement.gameStatement.enemiesAlive++;
    //                    GameStatement.beginGenereate = true;
    //                    GUIEnemyNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
    //                }
    //                else if (enemiesNumber < GameStatement.levelStatement.maxEnemiesNumber)
    //                {
    //                    GameObject clone = Instantiate(enemyCubeStatement.getObj(), new Vector3(GameStatement.levelStatement.terrainMaxX / 2, 1, GameStatement.levelStatement.terrainMaxZ / 2), new Quaternion(0, 0, 0, 0)) as GameObject;
    //                    clone.name = "EnemyCube" + (enemiesNumber + 1);
    //                    clone.transform.parent = gameObject.transform;
    //                    enemiesNumber++;
    //                    GameStatement.gameStatement.enemiesAlive++;
    //                    GameStatement.beginGenereate = true;
    //                    GUIEnemyNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
    //                }
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
