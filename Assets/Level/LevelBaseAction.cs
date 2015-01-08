using UnityEngine;
using System.Collections;

public class LevelBaseAction : MonoBehaviour {

    protected int enemiesNumber;
    public EnemyBaseStatement enemyBaseStatement;
	// Use this for initialization
	protected void Start () {
        enemiesNumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void Refresh()
    {
        enemiesNumber = 0;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(obj);
        }
    }
}
