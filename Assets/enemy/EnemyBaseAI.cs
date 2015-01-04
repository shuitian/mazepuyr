using UnityEngine;
using System.Collections;

public class EnemyBaseAI : MonoBehaviour {

    public float attackDistance = 1F;
    public float moveSpeed = 1F;
    public float attackTimePerSecond = 1F;
    protected float nextAttackTimeLeft = 0F;
    protected bool canAttack = false;
    protected Transform m_SelfTransform;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected virtual void attack()
    {

    }

    protected virtual void move(Vector3 position1)
    {

    }
}
