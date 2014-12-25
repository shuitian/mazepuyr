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
        GameStatement.gameStatement.retFlag = true;
        Destroy(GameObject.FindGameObjectWithTag("GameController"));
        Destroy(GameObject.FindGameObjectWithTag("BulletGroup"));
        setActived();
        Screen.showCursor = true;
        Application.LoadLevel("start");
    }

    public void OnPause()
    {
        if (GameStatement.gameStatement.paused)
        {
            GameStatement.gameStatement.paused = false;
            GameObject.Find("pauseText").GetComponent<Text>().text = "暂停";
            Time.timeScale = GameStatement.savedTimeScale;
        }
        else
        {
            GameStatement.gameStatement.paused = true;
            GameObject.Find("pauseText").GetComponent<Text>().text = "取消暂停";
            GameStatement.savedTimeScale = Time.timeScale;
            Time.timeScale = 0;
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
        GameStatement.gameStatement.enemiesNumber = 0;
        Application.LoadLevel("level1");
    }

    public void OnNextLevel()
    {
        if (GameStatement.gameStatement.maxGameLevel+2 >= Application.levelCount)
        {
            MsgPanel.msgPanel.showSorry();
        }
        else
        {
            Application.LoadLevel(Application.levelCount + 1);
        }
    }
}
