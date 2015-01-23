using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GUIMsgPanel : MonoBehaviour
{

    static public GUIMsgPanel msgPanel;
    void Awake()
    {
        msgPanel = this;
    }

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void showLose()
    {
        GUIMenuControl.menuControl.OnPause();
        gameObject.GetComponentInChildren<Text>().text = " 对不起，你失败了！";
        
    }

    public void showWin()
    {
        GUIMenuControl.menuControl.OnPause();
        gameObject.GetComponentInChildren<Text>().text = " 恭喜你，你通过了！";
    }

    public void showSorry()
    {
        gameObject.GetComponentInChildren<Text>().text = " 对不起，没有下一关了！";
    }

    public void OnReplay()
    {
        GUIMenuControl.menuControl.OnPause();
        GameStatement.gameStatement.Refresh();
        PlayerBaseStatement.playerBaseStatement.Refresh();

        GameStatement.levelStatementIsDone = false;
        Application.LoadLevel(Application.loadedLevel);  
    }

    public void OnNextLevel()
    {
        if (Application.loadedLevel + 1 >= Application.levelCount)
        {
            showSorry();
        }
        else
        {
            GUIMenuControl.menuControl.OnPause();
            GameStatement.gameStatement.Refresh();

            GameStatement.levelStatementIsDone = false;
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
