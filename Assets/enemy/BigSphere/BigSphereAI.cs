using UnityEngine;
using System.Collections;
using System;

public class BigSphereAI : EnemyBaseAI
{
    public float produceIntervalTime = 1F;
    public int produceNumberPerIntervalTime = 5;
    public GameObject sphereEnemy;
	// Use this for initialization
	void Start () {
        sphereEnemy = Resources.Load("prefab/Enemy/SphereEnemy") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        produceIntervalTime -= Time.deltaTime;
        //print(produceIntervalTime);
        if (produceIntervalTime <= 0)
        {
            if (GameStatement.gameStatement.enemiesAlive <= 150)
            {
                produceManySphere(produceNumberPerIntervalTime);
                produceIntervalTime = 1F;
            }
        }
	}

    void produceManySphere(int number)
    {
        for (int i = 0; i < number; i++)
        {
            prodeceOneSphere();
        }
    }

    void prodeceOneSphere()
    {
        Vector2 a = Vector2.Lerp(Vector2.up, -Vector2.up, UnityEngine.Random.Range(0F, 1F));
        Vector2 b = Vector2.Lerp(Vector2.right, -Vector2.right, UnityEngine.Random.Range(0F, 1F));
        Vector2 c = (a + b).normalized * 50;
        GameObject clone = Instantiate(sphereEnemy, new Vector3(GameStatement.levelStatement.terrainMaxX / 2 , 0, GameStatement.levelStatement.terrainMaxZ / 2), new Quaternion(0, 0, 0, 0)) as GameObject;
        clone.transform.parent = transform.parent.parent;
        clone.transform.position = transform.position + new Vector3(c.x, 1, c.y);
        clone.name = "SphereEnemy";
        GameStatement.gameStatement.enemiesAlive++;
        EnemiesNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
    }

    
}
