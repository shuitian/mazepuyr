using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;
using Regame;

public class GUIControl : MonoBehaviour {

    public static GUIControl control;

    public GameObject controlPanel;

    public Text showMsgText;

    protected void Awake()
    {
        control = this;
        Message.RegeditMessageHandle<string>("Pause", OnPause);
        Message.RegeditMessageHandle<string>("Resume", OnResume);

        Message.RegeditMessageHandle<string>("PassLevel", showWin);
        Message.RegeditMessageHandle<string>("LoseLevel", showLose);
    }

    protected void OnDestroy()
    {
        Message.UnregeditMessageHandle<string>("Pause", OnPause);
        Message.UnregeditMessageHandle<string>("Resume", OnResume);

        Message.UnregeditMessageHandle<string>("PassLevel", showWin);
        Message.UnregeditMessageHandle<string>("LoseLevel", showLose);
    }

    public void OnReturn()
    {
        Message.RaiseOneMessage<string>("Resume", this, "");
        Message.RaiseOneMessage<string>("Return", this, "");
    }

    public void Pause()
    {
        Message.RaiseOneMessage<string>("Pause", this, "");
    }

    public void Resume()
    {
        Message.RaiseOneMessage<string>("Resume", this, "");
    }

    void OnPause(string messageName, object sender, string empty)
    {
        controlPanel.SetActive(true);
        showMsgText.text = "";
    }

    void OnResume(string messageName, object sender, string empty)
    {
        controlPanel.SetActive(false);
    }

    void showLose(string messageName, object sender, string empty)
    {
        Message.RaiseOneMessage<string>("Pause", this, "");
        showMsgText.text = " 对不起，你失败了！";

    }

    void showWin(string messageName, object sender, string empty)
    {
        Message.RaiseOneMessage<string>("Pause", this, "");
        showMsgText.text = " 恭喜你，你通过了！";
    }

    public void showSorry()
    {
        showMsgText.text = " 对不起，没有下一关了！";
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
