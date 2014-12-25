using UnityEngine;
using System.Collections;

public class HitSomething : MonoBehaviour {

    //public GameObject explosionPrefab;
	// Use this for initialization
	void Start () {
        //explosionPrefab = Instantiate(Resources.Load("Standard Assets/Particles/Legacy Particles/explosion")) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= Level1Statement.terrainMinY || transform.position.x <= Level1Statement.terrainMinX || transform.position.z <= Level1Statement.terrainMinZ ||
                        transform.position.x >= Level1Statement.terrainMaxX || transform.position.y >= Level1Statement.terrainMaxY || transform.position.z >= Level1Statement.terrainMaxZ)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.isStatic)
        {
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            //collider.gameObject.GetComponent<EnemyStatement>().damaged(GetComponent<BulletParameter>().playerStatement, GetComponent<BulletParameter>().damage);
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("2");
    //}


}
