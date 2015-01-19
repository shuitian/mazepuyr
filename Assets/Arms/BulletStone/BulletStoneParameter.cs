using UnityEngine;
using System.Collections;

public class BulletStoneParameter : BulletBaseParameter
{
    protected void Awake()
    {
        base.Awake();
        baseDamage = 1;
        speed = 100;
    }

	// Use this for initialization
	protected void Start () {
        base.Start();
	}

    protected void OnEnable()
    {
        base.OnEnable();
    }

	// Update is called once per frame
	protected void Update () {
        base.Update();
	}
}
