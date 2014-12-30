using UnityEngine;
using System.Collections;

public class CreateLevel2Enemies : CreateLevelEnemies
{

    public SphereEnemyStatement sphereEnemyStatement;
    public CubeEnemyStatement cubeEnemyStatement;
    // Use this for initialization
    void Start()
    {
        base.Start();
        sphereEnemyStatement = GetComponent<SphereEnemyStatement>();
        cubeEnemyStatement = GetComponent<CubeEnemyStatement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (GameStatement.levelStatementIsDone)
            {
                if (enemiesNumber < GameStatement.levelStatement.maxEnemiesNumber / 2)
                {
                    GameObject clone = Instantiate(sphereEnemyStatement.getObj(), new Vector3(GameStatement.levelStatement.terrainMaxX / 2, 1, GameStatement.levelStatement.terrainMaxZ / 2), new Quaternion(0, 0, 0, 0)) as GameObject;
                    clone.name = "SphereEnemy" + (enemiesNumber + 1);
                    clone.transform.parent = gameObject.transform;
                    enemiesNumber++;
                    GameStatement.gameStatement.enemiesAlive++;
                    EnemiesNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
                }
                else if (enemiesNumber < GameStatement.levelStatement.maxEnemiesNumber)
                {
                    GameObject clone = Instantiate(cubeEnemyStatement.getObj(), new Vector3(GameStatement.levelStatement.terrainMaxX / 2, 1, GameStatement.levelStatement.terrainMaxZ / 2), new Quaternion(0, 0, 0, 0)) as GameObject;
                    clone.name = "CubeEnemy" + (enemiesNumber + 1);
                    clone.transform.parent = gameObject.transform;
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
