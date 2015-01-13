using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GUIMsgPanel : MonoBehaviour
{

    static public GUIMsgPanel msgPanel;
    void Awake()
    {
        msgPanel = GetComponent<GUIMsgPanel>();
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
        //Message.raiseOneMessage(new Message.ON_PAUSE(), this, new BaseEventArgs());
        GUIMenuControl.menuControl.OnPause();
        gameObject.GetComponentInChildren<Text>().text = " 对不起，你失败了！";
        
    }

    public void showWin()
    {
        //Message.raiseOneMessage(new Message.ON_PAUSE(), this, new BaseEventArgs());
        GUIMenuControl.menuControl.OnPause();
        gameObject.GetComponentInChildren<Text>().text = " 恭喜你，你通过了！";
    }

    public void showSorry()
    {
        msgPanel.gameObject.SetActive(true);
        gameObject.GetComponentInChildren<Text>().text = " 对不起，没有下一关了！";

    }

    public void OnReplay()
    {
        //Message.raiseOneMessage(new Message.ON_PAUSE(), this, new BaseEventArgs());
        GUIMenuControl.menuControl.OnPause();
        GameStatement.gameStatement.Refresh();
        PlayerBaseStatement.playerBaseStatement.Refresh();
        GameStatement.levelStatement.Refresh();

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
            //Message.raiseOneMessage(new Message.ON_PAUSE(), this, new BaseEventArgs());
            GUIMenuControl.menuControl.OnPause();
            GameStatement.gameStatement.Refresh();
            GameStatement.levelStatement.Refresh();
            GameStatement.levelStatementIsDone = false;
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
