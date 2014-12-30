using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemiesNumberShow : MonoBehaviour {

    static public EnemiesNumberShow enemiesNumberShow;
    static public GameObject enemyNumberText;
	// Use this for initialization
	void Start () {
        enemiesNumberShow = GetComponent<EnemiesNumberShow>();
        enemyNumberText = GameObject.Find("enemyNumberText");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updateGUI(int enemiesNumber)//try-catch
    {
        enemyNumberText.GetComponent<Text>().text = enemiesNumber + "";
    }
}
