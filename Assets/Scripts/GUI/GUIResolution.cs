﻿using UnityEngine;
using System.Collections;
using System;
using Regame;

public class GUIResolution : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject introductionPanel;

    void Awake()
    {
        Message.RegeditMessageHandle<string>("LevelIsDone", showGUI);
    }

    void OnDestroy()
    {
        Message.UnregeditMessageHandle<string>("LevelIsDone", showGUI);
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

    void showGUI(string messageName, object sender, string empty)
    {
        introductionPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}