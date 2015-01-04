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
                    GameObject clone = Instantiate(sphereEnemyStatement.getObj(), new Vector3(Random.Range(GameStatement.levelStatement.terrainMinX + 1, GameStatement.levelStatement.terrainMaxX - 1), MyTerrainData.terrainData.GetHeight(GameStatement.levelStatement.terrainMaxX / 2, GameStatement.levelStatement.terrainMaxZ / 2) + sphereEnemyStatement.getObj().transform.localScale.y/2, Random.Range(GameStatement.levelStatement.terrainMinZ + 1, GameStatement.levelStatement.terrainMaxZ - 1)),Quaternion.identity) as GameObject;
                    clone.name = "SphereEnemy" + (enemiesNumber + 1);
                    clone.transform.parent = transform;
                    enemiesNumber++;
                    GameStatement.gameStatement.enemiesAlive++;
                    GameStatement.beginGenereate = true;
                    EnemiesNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
                }
            }
        }
        finally
        {
        }
	}

    
}
