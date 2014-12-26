using UnityEngine;
using System.Collections;

public class BulletCollision : BaseCollision
{

	// Use this for initialization
	void Start () {
        //base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}

    //void OnTriggerEnter(Collider collider)
    //{
    //    base.OnTriggerEnter(collider);
    //    if (collider.gameObject.tag == "Enemy")
    //    {
    //        collider.gameObject.GetComponent<EnemyBaseStatement>().getDamaged(gameObject.GetComponent<BulletParameter>().playerBaseStatement, gameObject.GetComponent<BulletParameter>().damage);
    //    }
    //}
}
