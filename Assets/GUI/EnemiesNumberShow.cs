using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemiesNumberShow : MonoBehaviour {

    static public EnemiesNumberShow enemiesNumberShow;
	// Use this for initialization
	void Start () {
        enemiesNumberShow = GameObject.Find("enemyNumberText").GetComponent<EnemiesNumberShow>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updateGUI(int enemiesNumber)
    {
        gameObject.GetComponent<Text>().text = enemiesNumber+"";
    }
}
