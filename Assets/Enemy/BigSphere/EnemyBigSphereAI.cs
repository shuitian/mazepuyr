using UnityEngine;
using System.Collections;
using System;

public class EnemyBigSphereAI : EnemyBaseAI
{
    //public float produceIntervalTime = 1F;
    public int produceNumberPerIntervalTime = 1;
    public GameObject createdObject;
    public int maxNumber = 200;

    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
    }

	// Use this for initialization
	protected void Start () {
        base.Start();
        moveSpeed = 0;
        produceNumberPerIntervalTime = 5;
        attackTimePerSecond = 1F;
        attackDistance = 2000;
	}
	
	// Update is called once per frame
	protected void Update () {
        base.Update();
	}


    protected override void attack(GameObject enemy)
    {
        base.attack(enemy);
        if (baseStatement.childNumber < maxNumber)
        {
            produceManySphere(produceNumberPerIntervalTime);
            canAttack = false;
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
        GameObject clone = Instantiate(createdObject, new Vector3(transform.position.x, MyTerrainData.terrainData.GetHeight((Int32)transform.position.x, (Int32)transform.position.z), transform.position.z), Quaternion.identity) as GameObject;

        baseStatement.childNumber++;
        GameStatement.gameStatement.addEnemyAlive();

        clone.transform.parent = transform.parent.parent;
        clone.transform.position += new Vector3(c.x, createdObject.transform.lossyScale.y / 2, c.y);

        clone.GetComponentInChildren<BaseStatement>().setFatherStatemnt(baseStatement);
        clone.GetComponentInChildren<EnemyBaseAI>().setBaseEnemyObject(getBaseEnemyObject());
        clone.tag = tag;
        clone.GetComponentInChildren<ShowPosition>().gameObject.tag = tag;
        clone.name = createdObject.name;
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
