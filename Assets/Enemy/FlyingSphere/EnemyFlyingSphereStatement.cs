using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyFlyingSphereStatement : EnemyBaseStatement
{

	// Use this for initialization
    protected void Awake()
    {
        base.Awake();
        setEnemyObject("prefab/Enemy/青球");
        obj.name = "青球";
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
