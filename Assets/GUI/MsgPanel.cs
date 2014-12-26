using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MsgPanel : MonoBehaviour {

    static public MsgPanel msgPanel;
	// Use this for initialization
	void Start () {
        msgPanel = GetComponent<MsgPanel>();
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.SetActive(true);
	}

    public void showLose()
    {
        gameObject.SetActive(true);
        gameObject.GetComponentInChildren<Text>().text = " 对不起，你失败了！";
        
    }

    public void showWin()
    {
        gameObject.SetActive(true);
        gameObject.GetComponentInChildren<Text>().text = " 恭喜你，你通过了！";
        
    }

    public void showSorry()
    {
        gameObject.SetActive(true);
        gameObject.GetComponentInChildren<Text>().text = " 对不起，没有下一关了！";

    }
}
