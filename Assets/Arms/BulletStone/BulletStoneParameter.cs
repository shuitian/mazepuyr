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
	
	// Update is called once per frame
	protected void Update () {
        base.Update();
	}
}
