using UnityEngine;
using System.Collections;
using System;

public class Level3Action : LevelBaseAction
{
    static public GameObject bigSphere;
    public EnemyBigSphereStatement enemyBigSphereStatement;
    GameObject obj;
    void Awake()
    {
        Message.RegeditMessageHandle(new Message.LEVELISDONE(), BeginCreateEnemy);
        enemyBigSphereStatement = GetComponent<EnemyBigSphereStatement>();
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public override void Refresh()
    {
        base.Refresh();
    }

    public void BeginCreateEnemy(object sender, BaseEventArgs e)
    {
        try
        {
            if (gameObject)
            {
                if (obj == null)
                {
                    obj = enemyBigSphereStatement.getObj();
                }
                bigSphere = Instantiate(obj, new Vector3(GameStatement.levelStatement.terrainMaxX / 2, MyTerrainData.terrainData.GetHeight(GameStatement.levelStatement.terrainMaxX / 2, GameStatement.levelStatement.terrainMaxZ / 2) + obj.transform.localScale.y / 2, GameStatement.levelStatement.terrainMaxZ / 2), Quaternion.identity) as GameObject;
                bigSphere.GetComponentInChildren<EnemyBigSphereAI>().setCreatedObject("Prefab/Enemy/EnemySphere");
                bigSphere.GetComponentInChildren<EnemyBigSphereAI>().setMaxNumber(150);
                bigSphere.name = obj.name;
                bigSphere.transform.parent = gameObject.transform;
                enemiesNumber++;
                GameStatement.gameStatement.enemiesAlive++;
                GameStatement.beginGenereate = true;
                GUIEnemyNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
            }
            else
            {
                Message.RemoveMessageHandle(new Message.LEVELISDONE(), BeginCreateEnemy);
            }
        }
        catch(Exception e1)
        {
            Message.RemoveMessageHandle(new Message.LEVELISDONE(), BeginCreateEnemy);
        }
    }
}
