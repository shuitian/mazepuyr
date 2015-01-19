using UnityEngine;
using System.Collections;

[System.Serializable]
public class ObjectPool
{
    public GameObject prefab;
    public ArrayList objects;
    private int index = 0;

    public void setPrefab(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public void init()
    {
        objects = new ArrayList();
    }

    public GameObject getNextObjectInpool()
    {
        GameObject obj = null;
        for (int i = 0; i < objects.Count; i++)
        {
            obj = objects[index] as GameObject;
            if (!obj.activeSelf)
            {
                break;
            }
            index = (index + 1) % objects.Count;
        }
        if (objects.Count == 0 || obj.activeSelf)
        {
            obj = MonoBehaviour.Instantiate(prefab) as GameObject;
            obj.name = prefab.name + objects.Count;
            objects.Add(obj);
            index = 0;
            return obj;
        }
        index = (index + 1) % objects.Count;
        return obj;
    }

    public void clear()
    {
        foreach (GameObject obj in objects)
        {
            MonoBehaviour.Destroy(obj);
        }
        objects = new ArrayList();
        index = 0;
    }
}
