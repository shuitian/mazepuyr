using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyPool : MonoBehaviour
{

    public ObjectPool[] objectPools;
    public static EnemyPool enemyPool;
    public static Transform transformEnemyPool;
    public static ArrayList patients;
    //public static Mutex patientsLock;
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //patientsLock = new Mutex();
        patients = new ArrayList();
        enemyPool = this;
        transformEnemyPool = transform;
        for (int i = 0; i < objectPools.Length; i++)
        {
            objectPools[i].init();
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print(patients.Count);
    }

    static public GameObject Enemy(GameObject prefab, Vector2 position, Quaternion rotation)
    {
        Vector3 p;
        if (MyTerrainData.terrainData != null)
        {
            p = new Vector3(position.x, MyTerrainData.terrainData.GetHeight((int)position.x, (int)position.y), position.y);
        }
        else
        {
            p = new Vector3(position.x, 0, position.y);
        }
        return Enemy(prefab, p + new Vector3(0, prefab.transform.lossyScale.y / 2, 0), rotation);
    }

    static public GameObject[] Enemy(GameObject prefab, Vector3 position, Quaternion rotation, int number)
    {
        GameObject[] objs = new GameObject[number];
        for (int i = 0; i < number; i++)
        {
            objs[i] = Enemy(prefab, position, rotation);
        }
        return objs;
    }

    static public GameObject Enemy(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        ObjectPool objectPool = null;
        foreach (ObjectPool objectPoolTemp in enemyPool.objectPools)
        {
            if (objectPoolTemp.prefab == prefab)
            {
                objectPool = objectPoolTemp;
                break;
            }
        }
        if (objectPool == null)
        {
            GameStatement.gameStatement.addEnemyAlive(1);
            return Instantiate(prefab, position, rotation) as GameObject;
        }
        GameObject obj = objectPool.getNextObjectInpool();
        obj.transform.SetParent(transformEnemyPool);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);
        GameStatement.gameStatement.addEnemyAlive(1);
        return obj;
    }

    static public void Destroy(GameObject objectToDestroy)
    {
        if (objectToDestroy.activeSelf)
        {
            objectToDestroy.SetActive(false);
            GameStatement.gameStatement.subEnemyAlive(1);
        }
    }

    public void Refresh()
    {
        foreach (ObjectPool objectPool in enemyPool.objectPools)
        {
            objectPool.clear();
        }
    }
}
