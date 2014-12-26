using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuControl : MonoBehaviour {

    static public MenuControl menuControl;
    // Use this for initialization
    void Start()
    {
        menuControl = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<MenuControl>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnLevelWasLoaded(int level)
    {
        setActived();
    }


    public void OnReturn()
    {
        GameStatement.gameStatement.gameLevel = 0;
        Destroy(GameObject.FindGameObjectWithTag("GameController"));
        Destroy(GameObject.FindGameObjectWithTag("BulletGroup"));
        setActived();
        Screen.showCursor = true;
        Application.LoadLevel("start");
        GameStatement.levelStatementIsDone = false;
    }

    public void OnPause()
    {
        if (GameStatement.gameStatement.paused)
        {
            GameStatement.gameStatement.paused = false;
            GameObject.Find("pauseText").GetComponent<Text>().text = "暂停";
            Time.timeScale = GameStatement.savedTimeScale;
            MsgPanel.msgPanel.gameObject.SetActive(false);
        }
        else
        {
            GameStatement.gameStatement.paused = true;
            GameObject.Find("pauseText").GetComponent<Text>().text = "取消暂停";
            GameStatement.savedTimeScale = Time.timeScale;
            Time.timeScale = 0;
            MsgPanel.msgPanel.gameObject.SetActive(true);
        }
    }

    public void setActived()
    {
        if (GameStatement.gameStatement.paused)
        {
            GameStatement.gameStatement.paused = false;
            GameObject.Find("pauseText").GetComponent<Text>().text = "暂停";
            Time.timeScale = GameStatement.savedTimeScale;
        }
    }

    public void OnReplay()
    {
        GameObject.FindGameObjectWithTag("EnemyGenerator").GetComponent<CreateLevelEnemies>().Refresh();
        GameStatement.gameStatement.Refresh(Application.loadedLevel);
        PlayerBaseStatement.playerBaseStatement.Refresh();
        GameStatement.levelStatementIsDone = false;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void OnNextLevel()
    {
        //print(Application.loadedLevel);
        //print(Application.levelCount);
        if (Application.loadedLevel + 1 >= Application.levelCount)
        {
            MsgPanel.msgPanel.showSorry();
        }
        else
        {
            GameStatement.levelStatementIsDone = false;
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
