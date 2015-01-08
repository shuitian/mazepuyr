using UnityEngine;
using System.Collections;
using System;

public class Level5Action : LevelBaseAction
{

    //public EnemySphereStatement enemySphereStatement;
    //public EnemyFlyingSphereStatement enemyFlyingSphereStatement;
    public EnemyYellowSphereStatement enemyYellowSphereStatement;

    bool flag;
    GameObject obj;
    Vector3 p1,p2,p3,p4;
    int step;
    int origin;
    // Use this for initialization
    void Awake()
    {
        //Message.RegeditMessageHandle(new Message.LEVELISDONE(), BeginCreateEnemy);
        //enemySphereStatement = GetComponent<EnemySphereStatement>();
        //enemyFlyingSphereStatement = GetComponent<EnemyFlyingSphereStatement>();
        enemyYellowSphereStatement = GetComponent<EnemyYellowSphereStatement>();
    }
    void Start()
    {
        base.Start();
        flag = false;
        origin = 600;
        step = 30;
        obj = enemyYellowSphereStatement.getObj();
        p1 = new Vector3(origin, 50, origin);
        p2 = new Vector3(2000 - origin, 50, origin);
        p3 = new Vector3(2000 - origin, 50, 2000 - origin);
        p4 = new Vector3(origin, 50, 2000 - origin);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!flag && GameStatement.levelStatementIsDone)
        {
            if (p1.x >= 2000 - origin)
            {
                flag = true;
                return;
            }
            else
            {
                GameObject clone;
                clone = Instantiate(obj, p1, Quaternion.identity) as GameObject;
                clone.name = obj.name + (enemiesNumber + 1);
                clone.transform.parent = gameObject.transform;
                enemiesNumber++;
                p1 += new Vector3(step, 0, 0);

                clone = Instantiate(obj, p2, Quaternion.identity) as GameObject;
                clone.name = obj.name + (enemiesNumber + 1);
                clone.transform.parent = gameObject.transform;
                enemiesNumber++;
                p2 += new Vector3(0, 0, step);

                clone = Instantiate(obj, p3, Quaternion.identity) as GameObject;
                clone.name = obj.name + (enemiesNumber + 1);
                clone.transform.parent = gameObject.transform;
                enemiesNumber++;
                p3 -= new Vector3(step, 0, 0);

                clone = Instantiate(obj, p4, Quaternion.identity) as GameObject;
                clone.name = obj.name + (enemiesNumber + 1);
                clone.transform.parent = gameObject.transform;
                enemiesNumber++;
                p4 -= new Vector3(0, 0, step);

                if (enemiesNumber > 30)
                {
                    GameStatement.beginGenereate = true;
                }
                GameStatement.gameStatement.enemiesAlive+=4;
                GUIEnemyNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
            }
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
