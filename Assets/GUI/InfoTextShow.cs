using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoTextShow : MonoBehaviour {

    bool flag = false;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!flag && GameStatement.levelStatementIsDone)
        {
            GetComponentInChildren<Text>().text = GameStatement.levelStatement.info;
            flag = true;
        }
	}
}
