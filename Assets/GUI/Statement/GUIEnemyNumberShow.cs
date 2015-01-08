using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIEnemyNumberShow : MonoBehaviour
{

    static public GUIEnemyNumberShow enemiesNumberShow;
    static public GameObject enemyNumberText;

    void Awake()
    {
        enemiesNumberShow = GetComponent<GUIEnemyNumberShow>();
        enemyNumberText = GameObject.Find("enemyNumberText");
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updateGUI(int enemiesNumber)//try-catch
    {
        enemyNumberText.GetComponent<Text>().text = enemiesNumber + "";
    }
}
