using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuControl : MonoBehaviour {

    static public MenuControl menuControl;
    // Use this for initialization
    void Start()
    {
        Resolution.controlPanel = transform;
        menuControl = GetComponent<MenuControl>();
        Resolution.controlPanel = transform;
        gameObject.SetActive(false);
        Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(Screen.width / 2 - 60 - Screen.width / 25, Screen.height / 2 - 45 - Screen.height / 25, 0);
	}

    void OnLevelWasLoaded(int level)
    {
        //setActived();
    }


    public void OnReturn()
    {
        OnPause();
        GameStatement.gameStatement.gameLevel = 0;
        Destroy(GameObject.FindGameObjectWithTag("GameController"));
        Destroy(GameObject.FindGameObjectWithTag("BulletGroup"));
        Screen.showCursor = true;
        GameStatement.levelStatementIsDone = false;
        Application.LoadLevel("start");
    }

    public void OnPause()
    {
        if (GameStatement.gameStatement.paused)
        {
            MsgPanel.msgPanel.gameObject.SetActive(false);
            menuControl.gameObject.SetActive(false);
            Screen.showCursor = false;
            GameStatement.gameStatement.paused = false;
            Time.timeScale = GameStatement.savedTimeScale;
        }
        else
        {
            MsgPanel.msgPanel.gameObject.SetActive(true);
            menuControl.gameObject.SetActive(true);
            Screen.showCursor = true;
            GameStatement.gameStatement.paused = true;
            GameObject.Find("pauseText").GetComponent<Text>().text = "取消暂停";
            GameStatement.savedTimeScale = Time.timeScale;
            Time.timeScale = 0;
            MsgPanel.msgPanel.GetComponentInChildren<Text>().text = "";
        }
    }

    //public void setActived()
    //{
    //    if (GameStatement.gameStatement.paused)
    //    {
    //        GameStatement.gameStatement.paused = false;
    //        GameObject.Find("pauseText").GetComponent<Text>().text = "暂停";
    //        Time.timeScale = GameStatement.savedTimeScale;
    //    }
    //}
}
