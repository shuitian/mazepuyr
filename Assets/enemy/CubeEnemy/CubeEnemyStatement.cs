using UnityEngine;
using System.Collections;
using System.Threading;

public class CubeEnemyStatement : EnemyBaseStatement
{

	// Use this for initialization
	void Start () {
        base.Start();
        setEnemyObject("Prefab/Enemy/CubeEnemy");
        obj.name = "CubeEnemy";
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
}
