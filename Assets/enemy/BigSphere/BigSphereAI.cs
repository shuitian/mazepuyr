using UnityEngine;
using System.Collections;
using System;

public class BigSphereAI : EnemyBaseAI
{
    public float produceIntervalTime = 1F;
    public int produceNumberPerIntervalTime = 5;
    public GameObject createdObject;
	// Use this for initialization
	void Start () {
        //createdObject = Resources.Load("prefab/Enemy/SphereEnemy") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position1;
        try
        {
            position1 = PlayerBaseStatement.player.transform.position;
        }
        catch (Exception e)
        {
            position1 = Vector3.zero;
        }
        transform.parent.Find("Canvas").LookAt(position1, Vector3.up);
        if (createdObject == null)
        {
            return;
        }
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
        GameObject clone = Instantiate(createdObject, new Vector3(transform.position.x, MyTerrainData.terrainData.GetHeight(GameStatement.levelStatement.terrainMaxX / 2, GameStatement.levelStatement.terrainMaxZ / 2), transform.position.z), Quaternion.identity) as GameObject;
        clone.transform.parent = transform.parent.parent;
        clone.transform.position += new Vector3(c.x, createdObject.transform.lossyScale.y/2, c.y);
        clone.name = "Enemy";
        GameStatement.gameStatement.enemiesAlive++;
        EnemiesNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
    }

    public void setCreatedObject(string prefabPath)
    {
        createdObject = Resources.Load(prefabPath) as GameObject;
    }

    public void setCreatedObject(GameObject obj)
    {
        createdObject = obj;
    }
}
