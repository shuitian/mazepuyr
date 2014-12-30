using UnityEngine;
using System.Collections;

public class CreateLevel3Enemies : CreateLevelEnemies
{

    public BigSphereStatement bigSphereStatement;
    bool flag = false;
	// Use this for initialization
	void Start () {
        bigSphereStatement = GetComponent<BigSphereStatement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!flag &&GameStatement.levelStatementIsDone)
        {
            GameObject clone = Instantiate(bigSphereStatement.getObj(), new Vector3(GameStatement.levelStatement.terrainMaxX / 2 , 0, GameStatement.levelStatement.terrainMaxZ / 2), new Quaternion(0, 0, 0, 0)) as GameObject;
            flag = true;
            clone.name = "BigSphere";
            clone.transform.parent = gameObject.transform;
            enemiesNumber++;
            GameStatement.gameStatement.enemiesAlive++;
            EnemiesNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
        }
	}
}
