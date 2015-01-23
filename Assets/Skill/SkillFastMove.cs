using UnityEngine;
using System.Collections;

public class SkillFastMove : SkillMove
{
    private float baseSpeed;
	// Use this for initialization
	void Start () {
        baseSpeed = moveSpeed;
	}

    void OnEnable()
    {
        moveTo = PlayerBaseStatement.player;
    }

	// Update is called once per frame
	protected void Update () {
        base.Update();
	}

    protected void FixedUpdate()
    {
        base.FixedUpdate();
        moveSpeed = baseSpeed + dist / 10;
    }

}
