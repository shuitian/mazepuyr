using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Regame;

public class GUIEnemyNumberShow : MonoBehaviour
{
    public Text text;

    void Awake()
    {
        Message.RegeditMessageHandle<int>("UpdateEnemiesNumber", updateGUI);
    }

    void OnDestroy()
    {
        Message.UnregeditMessageHandle<int>("UpdateEnemiesNumber", updateGUI);
    }

    void updateGUI(string messageName, object sender, int enemiesNumber)
    {
        if (text)
        {
            text.text = enemiesNumber + "";
        }
    }
}
