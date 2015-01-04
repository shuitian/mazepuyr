using UnityEngine;
using System.Collections;

public class CreateLevel3Enemies : CreateLevelEnemies
{
    static public GameObject bigSphere;
    public BigSphereStatement bigSphereStatement;
    bool flag = false;
	// Use this for initialization
	void Start () {
        bigSphereStatement = GetComponent<BigSphereStatement>();

        if (!flag && GameStatement.levelStatementIsDone)
        {
            GameObject obj = bigSphereStatement.getObj();
            bigSphere = Instantiate(obj, new Vector3(GameStatement.levelStatement.terrainMaxX / 2, MyTerrainData.terrainData.GetHeight(GameStatement.levelStatement.terrainMaxX / 2, GameStatement.levelStatement.terrainMaxZ / 2) + obj.transform.localScale.y/2, GameStatement.levelStatement.terrainMaxZ / 2), Quaternion.identity) as GameObject;
            flag = true;
            bigSphere.GetComponentInChildren<BigSphereAI>().setCreatedObject("Prefab/Enemy/SphereEnemy");
            bigSphere.name = "BigSphere";
            bigSphere.transform.parent = gameObject.transform;
            enemiesNumber++;
            GameStatement.gameStatement.enemiesAlive++;
            GameStatement.beginGenereate = true;
            EnemiesNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public override void Refresh()
    {
        base.Refresh();
        flag = false;
        Start();
    }
}
