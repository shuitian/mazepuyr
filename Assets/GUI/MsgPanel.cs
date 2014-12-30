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
        gameObject.SetActive(true);
        gameObject.GetComponentInChildren<Text>().text = " 对不起，你失败了！";
        
    }

    public void showWin()
    {
        gameObject.SetActive(true);
        gameObject.GetComponentInChildren<Text>().text = " 恭喜你，你通过了！";
        
    }

    public void showSorry()
    {
        gameObject.SetActive(true);
        gameObject.GetComponentInChildren<Text>().text = " 对不起，没有下一关了！";

    }

    public void OnReplay()
    {
        try
        {
            GameObject.FindGameObjectWithTag("EnemyGenerator").GetComponent<CreateLevelEnemies>().Refresh();
            GameStatement.gameStatement.Refresh(Application.loadedLevel);
            PlayerBaseStatement.playerBaseStatement.Refresh();
        }
        //catch (Exception e)
        //{
        //    return;
        //}
        finally
        {
            GameStatement.levelStatementIsDone = false;
            Application.LoadLevel(Application.loadedLevel);
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
            GameStatement.levelStatementIsDone = false;
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
