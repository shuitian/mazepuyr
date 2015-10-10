using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using Regame;

public class GUIMsgPanel : MonoBehaviour
{
    static public GUIMsgPanel msgPanel;
    void Awake()
    {
        Message.RegeditMessageHandle<string>("PassLevel", showWin);
        Message.RegeditMessageHandle<string>("LoseLevel", showLose);
        Message.RegeditMessageHandle<string>("Pause", OnPause);
        Message.RegeditMessageHandle<string>("Resume", OnResume);
        msgPanel = this;
    }

    void OnDestroy()
    {
        Message.UnregeditMessageHandle<string>("PassLevel", showWin);
        Message.UnregeditMessageHandle<string>("LoseLevel", showLose);
        Message.UnregeditMessageHandle<string>("Pause", OnPause);
        Message.UnregeditMessageHandle<string>("Resume", OnResume);
    }

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}

    void OnPause(string messageName, object sender, string empty)
    {
        gameObject.SetActive(true);
        GetComponentInChildren<Text>().text = "";
    }

    void OnResume(string messageName, object sender, string empty)
    {
        gameObject.SetActive(false);
    }

    void showLose(string messageName, object sender, string empty)
    {
        Message.RaiseOneMessage<string>("Pause", this, "");
        gameObject.GetComponentInChildren<Text>().text = " 对不起，你失败了！";
        
    }

    void showWin(string messageName, object sender, string empty)
    {
        Message.RaiseOneMessage<string>("Pause", this, "");
        gameObject.GetComponentInChildren<Text>().text = " 恭喜你，你通过了！";
    }

    public void showSorry()
    {
        gameObject.GetComponentInChildren<Text>().text = " 对不起，没有下一关了！";
    }

    public void OnReplay()
    {
        Message.RaiseOneMessage<string>("Resume", this, "");
        Message.RaiseOneMessage<string>("Replay", this, "");
    }

    public void OnNextLevel()
    {
        if (Application.loadedLevel + 1 >= Application.levelCount)
        {
            showSorry();
        }
        else
        {
            Message.RaiseOneMessage<string>("Resume", this, "");
            Message.RaiseOneMessage<string>("NextLevel", this, "");
        }
    }
}
