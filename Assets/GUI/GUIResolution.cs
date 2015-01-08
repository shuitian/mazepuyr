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
        gamePanel = transform.Find("gamePanel").gameObject;
        introductionPanel = transform.Find("introductionPanel").gameObject;
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
                //Message.raiseOneMessage(new Message.ON_PAUSE(), this, new BaseEventArgs());
                GUIMenuControl.menuControl.OnPause();
            }
        }
	}

    void showGUI(object sender, BaseEventArgs e)
    {
        try
        {
            introductionPanel.SetActive(false);
            gamePanel.SetActive(true);
        }
        catch (Exception e1)
        {
            Message.RemoveMessageHandle(new Message.LEVELISDONE(), showGUI);
        }
    }
}
