using UnityEngine;
using System.Collections;

public class SkillFastMove : SkillMove
{
    private float baseSpeed;
	// Use this for initialization
	void Start () {
        baseSpeed = moveSpeed;
	}

    protected void FixedUpdate()
    {
        base.FixedUpdate();
        moveSpeed = baseSpeed + dist / 10;
    }
}
