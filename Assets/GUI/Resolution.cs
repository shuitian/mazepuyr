using UnityEngine;
using System.Collections;

public class Resolution : MonoBehaviour {

    static public int width;
    static public int height;
	// Use this for initialization
    static public Transform hpLabel;
    static public Transform hpText;
    static public Transform enemyNumberLabel;
    static public Transform enemyNumberText;
    static public Transform btnReturn;
    static public Transform btnPause;
    static public Transform infoText;

	void Start () {
        hpLabel = GameObject.Find("hpLabel").transform;
        hpText = GameObject.Find("hpText").transform;
        enemyNumberLabel = GameObject.Find("enemyNumberLabel").transform;
        enemyNumberText = GameObject.Find("enemyNumberText").transform;
        btnReturn = GameObject.Find("btnReturn").transform;
        btnPause = GameObject.Find("btnPause").transform;
        infoText = GameObject.Find("infoText").transform;
	}
	
	// Update is called once per frame
	void Update () {
        width = Screen.width;
        height = Screen.height;
        hpLabel.localPosition = new Vector3(-width / 2 + 80 + width/25, height / 2 - 20 - height/25, 0);
        hpText.localPosition = new Vector3(-width / 2 + 160 + width / 25, height / 2 - 20 - height / 25, 0);
        enemyNumberLabel.localPosition = new Vector3(-width / 2 + 80 + width / 25, height / 2 - 40 - height / 25, 0);
        enemyNumberText.localPosition = new Vector3(-width / 2 + 160 + width / 25, height / 2 - 40 - height / 25, 0);
        btnReturn.localPosition = new Vector3(width / 2 - 120 + width / 25, height / 2 - 20 - height / 25, 0);
        btnPause.localPosition = new Vector3(width / 2 - 120 + width / 25, height / 2 - 60 - height / 25, 0);
        infoText.localPosition = new Vector3(width / 2 - 160 + width / 25, -height / 2 + 70 - height / 25, 0);
	}

}
