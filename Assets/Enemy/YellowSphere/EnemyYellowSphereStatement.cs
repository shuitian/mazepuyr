using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyYellowSphereStatement : EnemySphereStatement
{

	// Use this for initialization
    protected void Awake()
    {
        base.Awake();
        setEnemyObject("Prefab/Enemy/EnemyYellowSphere");
        obj.name = "黄球";
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
