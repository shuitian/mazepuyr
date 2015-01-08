using UnityEngine;
using System.Collections;
using System;

public class EnemyBigSphereAI : EnemyBaseAI
{
    public float produceIntervalTime = 1F;
    public int produceNumberPerIntervalTime = 5;
    public GameObject createdObject;
    public int maxNumber = 200;
	// Use this for initialization
	void Start () {
        moveSpeed = 0;
	}
	
	// Update is called once per frame
	protected void Update () {
        base.Update();
	}

    protected override void doAction()
    {
        //base.doAction();
        produceIntervalTime -= Time.deltaTime;
        if (produceIntervalTime <= 0)
        {
            if (GameStatement.gameStatement.enemiesAlive <= maxNumber)
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
        clone.name = createdObject.name;
        GameStatement.gameStatement.enemiesAlive++;
        GUIEnemyNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
    }

    public void setCreatedObject(string prefabPath)
    {
        createdObject = Resources.Load(prefabPath) as GameObject;
    }

    public void setCreatedObject(GameObject obj)
    {
        createdObject = obj;
    }

    public void setMaxNumber(int n)
    {
        maxNumber = n;
    }
}
