using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GUIInfoTextShow : MonoBehaviour
{

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
        try
        {
            GetComponentInChildren<Text>().text = GameStatement.levelStatement.info;
        }
        catch (Exception e1)
        {
            Message.RemoveMessageHandle(new Message.LEVELISDONE(), setInfo);
        }
    }
}
