using UnityEngine;
using System.Collections;

public class SkillCreateChild : MonoBehaviour
{

    public GameObject toBeCreated;
    public BaseStatement toBeCreatedStatement;

    public GameObject creater;
    public BaseStatement createrStatement;

    public float createTimePerSecond = 1F;
    public int produceNumberPerIntervalTime = 5;
    public int maxNumber = 200;

    protected float lastCreateTime = 0;
    private int enemyNumber = 0;
    protected void Awake()
    {
    }
	// Use this for initialization
    protected void Start()
    {
	    
	}

    protected void OnEnable()
    {

    }

	// Update is called once per frame
    protected void Update()
    {
        if (createrStatement.childNumber < maxNumber && Time.time - lastCreateTime > 1 / createTimePerSecond) 
        {
            create(toBeCreated, produceNumberPerIntervalTime);
            lastCreateTime = Time.time;
        }
	}

    public void create(GameObject toBeCreated, int number = 1)
    {
        if (!toBeCreated)
        {
            return;
        }
        if (number < 1)
        {
            return;
        }
        GameObject obj = EnemyPool.Enemy(toBeCreated, getCreatedPosition(), Quaternion.identity);
        toBeCreatedStatement = obj.GetComponent<BaseStatement>();
        toBeCreatedStatement.fatherStatemnt = createrStatement;
        enemyNumber++;
        createrStatement.childNumber++;
        create(toBeCreated, number - 1);
    }

    public Vector3 getCreatedPosition()
    {
        Vector2 a = Vector2.Lerp(Vector2.up, -Vector2.up, UnityEngine.Random.Range(0F, 1F));
        Vector2 b = Vector2.Lerp(Vector2.right, -Vector2.right, UnityEngine.Random.Range(0F, 1F));
        Vector3 c = (a + b).normalized * creater.transform.lossyScale.x + new Vector2(creater.transform.position.x, creater.transform.position.z);
        return new Vector3(c.x, MyTerrainData.terrainData.GetHeight((int)c.x, (int)c.y) + toBeCreated.transform.lossyScale.y / 2, c.y);
    }
}
