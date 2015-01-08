using UnityEngine;
using System.Collections;

public class PlayerBaseStatement : BaseStatement {

    public float attackTimePerSecond = 10F;
    public float nextAttackTimeLeft = 0F;
    public bool canAttack = false;
    public Vector3 bornPosition;
    static public PlayerBaseStatement playerBaseStatement;
    static public GameObject player;
	// Use this for initialization
	protected void Awake () {
        base.Awake();
        maxHp = new float[] { 0F, 1000F, 1100F, 1200F, 1300F, 1400F, 1500F, 1600F, 1700F, 1800F, 1900F, 2000F };
        maxMp = new float[] { 0F, 100F, 110F, 120F, 130F, 140F, 150F, 160F, 170F, 180F, 190F, 200F };
        maxExpPerLevel = new float[] {0F, 50F, 100F, 150F, 200F, 250F, 300F, 350F, 400F, 450F, 500F, 550F};
        baseAttackPerLevel = new float[] {0F, 50F, 60F, 70F, 80F, 90F, 100F, 110F, 120F, 130F, 140F, 150F };
        baseDefensePerLevel = new float[] {0F, 0F, 0F, 1F, 1F, 1F, 1F, 2F, 2F, 2F, 3F, 3F, };
	}

    protected  void Start()
    {
        base.Start();
        attackTimePerSecond = 10F;
        nextAttackTimeLeft = 0F;
        canAttack = false;
    }

	// Update is called once per frame
	protected void Update () {
        base.Update();
        if (!canAttack)
        {
            nextAttackTimeLeft -= Time.deltaTime;
        }
        if (nextAttackTimeLeft <= 0)
        {
            nextAttackTimeLeft = 1 / attackTimePerSecond;
            canAttack = true;
        }
	}


    public virtual void Refresh()
    {
    }
}
