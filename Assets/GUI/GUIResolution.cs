using UnityEngine;
using System.Collections;
using System;

public class GUIResolution : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject introductionPanel;

    void Awake()
    {
        Message.RegeditMessageHandle(new Message.LEVELISDONE(), showGUI);
    }

	void Start () {
        gamePanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameStatement.levelStatementIsDone)
            {
                GUIMenuControl.menuControl.OnPause();
            }
        }
	}

    void showGUI(object sender, BaseEventArgs e)
    {
        introductionPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    void OnDestroy()
    {
        Message.RemoveMessageHandle(new Message.LEVELISDONE(), showGUI);
    }
}
