using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIEnemyNumberShow : MonoBehaviour
{

    static public GUIEnemyNumberShow enemiesNumberShow;
    public Text text;

    void Awake()
    {
        enemiesNumberShow = this;
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updateGUI(int enemiesNumber)//try-catch
    {
        text.text = enemiesNumber + "";
    }
}
