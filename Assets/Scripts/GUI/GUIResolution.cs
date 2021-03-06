﻿using UnityEngine;
using System.Collections;
using System;
using UnityTool.Libgame;

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

    void Start()
    {
        gamePanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (LevelBaseStatement.levelStatementIsDone)
            {
                if (UnityTool.Libgame.Time.isPaused)
                {
                    Message.RaiseOneMessage<string>("Resume", this, "");
                }
                else
                {
                    Message.RaiseOneMessage<string>("Pause", this, "");
                }
            }
        }
	}

    void showGUI(string messageName, object sender, string empty)
    {
        introductionPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}
