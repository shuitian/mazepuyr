using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartPage : MonoBehaviour {

    static public Transform btnBegin;
    static public Transform btnSet;
    static public Transform btnHelp;
    static public Transform btnExit;
    private GameObject panel;
	// Use this for initialization
	void Start () {
        panel = GameObject.Find("Panel");
        panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        btnBegin = GameObject.Find("start").transform;
        btnSet = GameObject.Find("set").transform;
        btnHelp = GameObject.Find("help").transform;
        btnExit = GameObject.Find("exit").transform;
        int width = Screen.width;
        int height = Screen.height;
        btnBegin.localPosition = new Vector3(0, 60, 0);
        btnSet.localPosition = new Vector3(0, 20, 0);
        btnHelp.localPosition = new Vector3(0, -20, 0);
        btnExit.localPosition = new Vector3(0, -60, 0);
	}

    public void OnStartClick()
    {
        GameStatement.gameStatement.gameLevel = 1;
        Application.LoadLevel("level1");
    }

    public void OnSetClick()
    {

    }

    public void OnHelpClick()
    {
        panel.SetActive(true);
        //rectTransform.rect =new Rect(0, 0, 10,10);
        //    Screen.width / 2 - Screen.width / 6;
        //rectTransform.Right = -rectTransform.Left;
        GameObject.Find("msgShow").GetComponent<Text>().text = "帮助信息\nW:前进\nA:左移\nS:后退\nD:右移\n空格:跳跃\n鼠标左键:攻击\n\n作者:puyr\nE-mail:mazepuyr@163.com\n版本:1.00\n";
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

}
