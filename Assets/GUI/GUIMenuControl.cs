using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIMenuControl : MonoBehaviour
{

    static public GUIMenuControl menuControl;
    void Awake()
    {
        menuControl = GetComponent<GUIMenuControl>();
    }

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void OnReturn()
    {
        OnPause();
        GameStatement.beginGenereate = false;
        GameStatement.gameStatement.gameLevel = 0;
        Screen.showCursor = true;
        GameStatement.levelStatementIsDone = false;
        Application.LoadLevel("start");
    }

    public void OnPause()
    {
        if (GameStatement.gameStatement.paused)
        {
            Time.timeScale = GameStatement.savedTimeScale;
            Screen.showCursor = false;

            GUIMsgPanel.msgPanel.gameObject.SetActive(false);
            menuControl.gameObject.SetActive(false);
            GameStatement.gameStatement.paused = false;
        }
        else
        {
            GameStatement.savedTimeScale = Time.timeScale;
            Time.timeScale = 0;
            Screen.showCursor = true;

            GUIMsgPanel.msgPanel.gameObject.SetActive(true);
            menuControl.gameObject.SetActive(true);
            GameStatement.gameStatement.paused = true;
            GameObject.Find("pauseText").GetComponent<Text>().text = "取消暂停";
            GUIMsgPanel.msgPanel.GetComponentInChildren<Text>().text = "";
        }
    }
}
