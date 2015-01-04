using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MsgPanel : MonoBehaviour {

    static public MsgPanel msgPanel;
	// Use this for initialization
	void Start () {
        msgPanel = GetComponent<MsgPanel>();
        Resolution.msgPanel = transform;
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.SetActive(true);
	}

    public void showLose()
    {
        MenuControl.menuControl.OnPause();
        msgPanel.gameObject.GetComponentInChildren<Text>().text = " 对不起，你失败了！";
        
    }

    public void showWin()
    {
        MenuControl.menuControl.OnPause();
        msgPanel.gameObject.GetComponentInChildren<Text>().text = " 恭喜你，你通过了！";
    }

    public void showSorry()
    {
        msgPanel.gameObject.SetActive(true);
        msgPanel.gameObject.GetComponentInChildren<Text>().text = " 对不起，没有下一关了！";

    }

    public void OnReplay()
    {
        try
        {
            MenuControl.menuControl.OnPause();
            GameObject.FindGameObjectWithTag("EnemyGenerator").GetComponent<CreateLevelEnemies>().Refresh();
            GameStatement.gameStatement.Refresh();
            GameStatement.levelStatement.Refresh();
            PlayerBaseStatement.playerBaseStatement.Refresh();

            GameStatement.levelStatementIsDone = false;
            Application.LoadLevel(Application.loadedLevel);
        }
        catch (Exception e)
        {
            GameStatement.levelStatement.Refresh();
            GameStatement.levelStatementIsDone = false;
            Application.LoadLevel(Application.loadedLevel);
        }
        finally
        {
            
        }
    }

    public void OnNextLevel()
    {
        if (Application.loadedLevel + 1 >= Application.levelCount)
        {
            showSorry();
        }
        else
        {
            MenuControl.menuControl.OnPause();
            GameStatement.gameStatement.Refresh();
            GameStatement.levelStatement.Refresh();
            GameStatement.levelStatementIsDone = false;
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
