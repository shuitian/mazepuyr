using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemySphereStatement : EnemyBaseStatement
{

	// Use this for initialization
    protected void Awake()
    {
        base.Awake();
        setEnemyObject("Prefab/Enemy/白球");
        obj.name = "白球";
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
