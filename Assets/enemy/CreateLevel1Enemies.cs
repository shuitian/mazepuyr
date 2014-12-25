using UnityEngine;
using System.Collections;

public class CreateLevel1Enemies : MonoBehaviour
{

    private CreateOneEnemy createOneEnemy;
    private GameObject enemyGenerator;
	// Use this for initialization
	void Start () {
        createOneEnemy = GetComponent<CreateOneEnemy>();
        enemyGenerator = GameObject.FindGameObjectWithTag("EnemyGenerator");
	}
	
	// Update is called once per frame
	void Update () {
        if (GameStatement.gameStatement.enemiesNumber < GameStatement.gameStatement.enemiesMaxNumber)
        {
            GameObject clone = Instantiate(createOneEnemy.getObj(), new Vector3(Random.Range(Level1Statement.terrainMinX + 1, Level1Statement.terrainMaxX - 1), 1, Random.Range(Level1Statement.terrainMinX + 1, Level1Statement.terrainMaxX - 1)), Random.rotation) as GameObject;
            clone.name = "SphereEnemy" + (GameStatement.gameStatement.enemiesNumber + 1);
            clone.transform.parent = enemyGenerator.transform;
            GameStatement.gameStatement.enemiesNumber++;
            GameStatement.gameStatement.enemiesAlive++;
            EnemiesNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
        }
	}

}
