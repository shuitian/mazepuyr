using UnityEngine;
using System.Collections;

public class EnemyPool : MonoBehaviour
{

    public ObjectPool[] objectPools;
    public static EnemyPool enemyPool;
    public static Transform transformEnemyPool;
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
            return Instantiate(prefab, position, rotation) as GameObject;
        }
        GameObject obj = objectPool.getNextObjectInpool();
        obj.transform.SetParent(transformEnemyPool);
        obj.transform.position = position;
        print(obj.transform.position);
        obj.transform.rotation = rotation;
        obj.SetActive(true);
        return obj;
    }

    static public void Destroy(GameObject objectToDestroy)
    {
        objectToDestroy.SetActive(false);
    }

    public void Refresh()
    {
        foreach (ObjectPool objectPool in enemyPool.objectPools)
        {
            objectPool.clear();
        }
    }
}
