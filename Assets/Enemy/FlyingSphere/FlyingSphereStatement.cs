using UnityEngine;
using System.Collections;
using System.Threading;

public class FlyingSphereStatement : EnemyBaseStatement
{

	// Use this for initialization
	void Start () {
        base.Start();
        setEnemyObject("prefab/Enemy/FlyingSphere");
        obj.name = "FlyingSphere";
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
