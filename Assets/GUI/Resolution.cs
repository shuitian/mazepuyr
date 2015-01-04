using UnityEngine;
using System.Collections;

public class Resolution : MonoBehaviour {

    static public int width;
    static public int height;
	// Use this for initialization
    public Transform statePanel;
    public Transform enemyPanel;
    static public Transform msgPanel;
    static public Transform controlPanel;
    public Transform infoPanel;
    bool flag;

	void Start () {
        statePanel = transform.Find("statePanel");
        enemyPanel = transform.Find("enemyPanel");
        //msgPanel = GameObject.Find("msgPanel").transform;
        //controlPanel = GameObject.Find("controlPanel").transform;
        infoPanel = transform.Find("infoPanel");
        flag = false;
	}
	
	// Update is called once per frame
	void Update () {
        width = Screen.width;
        height = Screen.height;
        statePanel.localPosition = new Vector3(-width / 2 + 100 + width / 25, height / 2 - 30 - height / 25, 0);
        enemyPanel.localPosition = new Vector3(-width / 2 + 80 + width / 25, height / 2 - 75 - height / 25, 0);
        //msgPanel.localPosition = new Vector3(0, 0, 0);
        //controlPanel.localPosition = new Vector3(width / 2 -60 - width / 25, height / 2 - 45 - height / 25, 0);
        infoPanel.localPosition = new Vector3(width / 2 - 125 - width / 25, -height / 2 + 45 + height / 25, 0);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if (GameStatement.levelStatement.getState() == 0)
            //{
                MenuControl.menuControl.OnPause();
            //}
        }
	}

}
