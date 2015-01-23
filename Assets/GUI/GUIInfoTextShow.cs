using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GUIInfoTextShow : MonoBehaviour
{
    public Text text;
    void Awake()
    {
        Message.RegeditMessageHandle(new Message.LEVELISDONE(), setInfo);
    }

	// Use this for initialization
	void Start () {
        //Message.RegeditMessageHandle(new Message.LEVELISDONE(), setInfo);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void setInfo(object sender, BaseEventArgs e)
    {
        text.text = GameStatement.levelStatement.info;
    }

    void OnDestroy()
    {
        Message.RemoveMessageHandle(new Message.LEVELISDONE(), setInfo);
    }
}
