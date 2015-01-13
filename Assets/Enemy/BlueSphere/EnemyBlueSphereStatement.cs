using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyBlueSphereStatement : EnemySphereStatement
{

	// Use this for initialization
    protected void Awake()
    {
        base.Awake();
        setEnemyObject("Prefab/Enemy/EnemyBlueSphere");
        obj.name = "蓝球";
	}

    protected void Start()
    {
        base.Start();
    }


	// Update is called once per frame
	void Update () {
        base.Update();
	}

}
