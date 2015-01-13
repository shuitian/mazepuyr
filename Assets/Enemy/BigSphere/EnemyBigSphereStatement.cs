using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyBigSphereStatement : EnemyBaseStatement
{
	// Use this for initialization
    protected void Awake()
    {
        base.Awake();
        deadExp = 20;
        baseGrowScaleExp = 100;
        maxHp = new float[] { 0F, 10000F, 20000F, 30000F, 40000F, 50000F, 60000F, 70000F, 80000F, 90000F, 100000F, 110000F };
        maxExpPerLevel = new float[] { 0F, 100F, 200F, 300F, 400F, 500F, 600F, 700F, 800F, 900F, 1000F, 1100F};
        setEnemyObject("prefab/Enemy/EnemyBigSphere");
        obj.name = "大球";
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
