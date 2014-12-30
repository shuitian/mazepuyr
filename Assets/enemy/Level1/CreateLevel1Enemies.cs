using UnityEngine;
using System.Collections;

public class CreateLevel1Enemies : CreateLevelEnemies
{

    public SphereEnemyStatement sphereEnemyStatement;
	// Use this for initialization
	void Start () {
        base.Start();
        sphereEnemyStatement = GetComponent<SphereEnemyStatement>();
	}
	
	// Update is called once per frame
	void Update () {
        try
        {
            if (GameStatement.levelStatementIsDone)
            {
                if (enemiesNumber < GameStatement.levelStatement.maxEnemiesNumber)
                {
                    GameObject clone = Instantiate(sphereEnemyStatement.getObj(), new Vector3(Random.Range(GameStatement.levelStatement.terrainMinX + 1, GameStatement.levelStatement.terrainMaxX - 1), 1, Random.Range(GameStatement.levelStatement.terrainMinZ + 1, GameStatement.levelStatement.terrainMaxZ - 1)), new Quaternion(0, 0, 0, 0)) as GameObject;
                    clone.name = "SphereEnemy" + (enemiesNumber + 1);
                    clone.transform.parent = transform;
                    enemiesNumber++;
                    GameStatement.gameStatement.enemiesAlive++;
                    EnemiesNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
                }
            }
        }
        finally
        {
        }
	}

    
}
