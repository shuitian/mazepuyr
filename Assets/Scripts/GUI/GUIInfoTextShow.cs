using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using Regame;

public class GUIInfoTextShow : MonoBehaviour
{
    public Text text;
    void Awake()
    {
        Message.RegeditMessageHandle<string>("LevelIsDone", setInfo);
    }

    void setInfo(string messageName, object sender, string empty)
    {
        text.text = GameStatement.levelStatement.info;
    }

    void OnDestroy()
    {
        Message.UnregeditMessageHandle<string>("LevelIsDone", setInfo);
    }
}
