using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyRedSphereStatement : EnemySphereStatement
{

	// Use this for initialization
    protected void Awake()
    {
        base.Awake();
        setEnemyObject("Prefab/Enemy/红球");
        obj.name = "红球";
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
