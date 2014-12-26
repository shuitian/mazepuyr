using UnityEngine;
using System.Collections;
using System.Threading;

public class CubeEnemyStatement : EnemyBaseStatement
{

	// Use this for initialization
	void Start () {
        base.Start();
        setEnemyObject("prefab/CubeEnemy");
        obj.name = "CubeEnemy";
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}

    

    void OnTriggerEnter(Collider collider)
    {
        getDamaged(collider.gameObject.GetComponent<BaseParameter>().playerBaseStatement, collider.gameObject.GetComponent<BaseParameter>().getDamage());
    }

}
