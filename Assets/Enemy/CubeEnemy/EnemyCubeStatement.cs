using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyCubeStatement : EnemyBaseStatement
{

	// Use this for initialization
    protected void Awake()
    {
        base.Awake();
        setEnemyObject("Prefab/Enemy/白色立方体");
        obj.name = "白色立方体";
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
