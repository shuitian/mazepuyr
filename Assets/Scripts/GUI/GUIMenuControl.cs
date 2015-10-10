using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Regame;

public class GUIMenuControl : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Awake()
    {
        Message.RegeditMessageHandle<string>("Pause", OnPause);
        Message.RegeditMessageHandle<string>("Resume", OnResume);
    }

    void OnDestroy()
    {
        Message.UnregeditMessageHandle<string>("Pause", OnPause);
        Message.UnregeditMessageHandle<string>("Resume", OnResume);
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
        gameObject.SetActive(true);
    }

    void OnResume(string messageName, object sender, string empty)
    {
        gameObject.SetActive(false);
    }
}
