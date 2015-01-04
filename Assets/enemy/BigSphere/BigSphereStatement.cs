using UnityEngine;
using System.Collections;
using System.Threading;

public class BigSphereStatement : EnemyBaseStatement
{
	// Use this for initialization
	void Start () {
        maxHp = 1000;
        exp = 20;
        base.Start();
        setEnemyObject("prefab/Enemy/BigSphere");
        obj.name = "BigSphere";
        if (transform.parent != null)
        {
            enemyBaseStatementShow = transform.parent.GetComponentInChildren<EnemyBaseStatementShow>();
            enemyBaseStatementShow.updateHpText(hp, maxHp);
            enemyBaseStatementShow.updateMpText(mp, maxMp);
            enemyBaseStatementShow.updateNameText(name);
        }
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}

    void OnTriggerEnter(Collider collider)//try-catch
    {
        getDamaged(collider.gameObject.GetComponent<BaseParameter>().playerBaseStatement, collider.gameObject.GetComponent<BaseParameter>().getDamage());
    }

    protected override void die(PlayerBaseStatement player)//try-catch
    {
        base.die(player);
        //player.passLevel();
    }
}
