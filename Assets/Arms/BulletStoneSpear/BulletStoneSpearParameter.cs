using UnityEngine;
using System.Collections;

public class BulletStoneSpearParameter : BulletBaseParameter
{
    protected void Awake()
    {
        base.Awake();
        baseDamage = 5;
        speed = 100F;
    }

	// Use this for initialization
	protected void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	protected void Update () {
        base.Update();
	}
}
