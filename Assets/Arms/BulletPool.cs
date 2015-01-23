using UnityEngine;
using System.Collections;

public class BulletPool : MonoBehaviour
{

    public ObjectPool[] objectPools;
    public static BulletPool bulletPool;
    public static Transform transformBulletPool;
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        bulletPool = this;
        transformBulletPool = transform;
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

    static public GameObject Bullet(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        ObjectPool objectPool = null;
        foreach (ObjectPool objectPoolTemp in bulletPool.objectPools)
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
        obj.transform.SetParent(transformBulletPool);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);
        return obj;
    }

    static public void Destroy(GameObject objectToDestroy)
    {
        if (objectToDestroy.activeSelf)
        {
            objectToDestroy.SetActive(false);
        }
    }

    public void Refresh()
    {
        foreach (ObjectPool objectPool in bulletPool.objectPools)
        {
            objectPool.clear();
        }
    }
}
