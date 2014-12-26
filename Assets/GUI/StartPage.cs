using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartPage : MonoBehaviour {

    static public Transform btnBegin;
    static public Transform btnSet;
    static public Transform btnHelp;
    static public Transform btnExit;
    private GameObject panel;
    private GameObject setupPanel;
    private GameObject levelPanel;
    private GameObject weaponPanel;
    private GameObject msgShow;
    private GameObject btnBack;
    private GameObject btnLevel;
    private GameObject setupMsgPanel;
    private GameObject btnLevel1;
    private GameObject btnWeapon;
    private GameObject btnBullet;
    private GameObject btnRay;
    int width;
    int height;
    private enum Option:int
    {
        home = 0,
        set = 1,
        help = 2,
    }
    private Option opt;
    private bool setLevelFlag;
    static private bool setWeaponFlag;

	// Use this for initialization
	void Start () {
        setLevelFlag = false;
        setWeaponFlag = false;
        opt = Option.home;
        btnBullet = GameObject.Find("btnBullet"); ;
        btnRay = GameObject.Find("btnRay"); ;
        levelPanel = GameObject.Find("levelPanel"); ;
        weaponPanel = GameObject.Find("weaponPanel"); ;
        btnWeapon = GameObject.Find("btnWeapon"); 
        btnLevel1 = GameObject.Find("btnLevel1"); 
        setupMsgPanel = GameObject.Find("setupMsgPanel");
        btnLevel = GameObject.Find("btnLevel");

        setupPanel = GameObject.Find("setupPanel");
        setupPanel.SetActive(false);

        msgShow = GameObject.Find("msgShow");
        msgShow.SetActive(false);

        btnBack = GameObject.Find("btnBack");
        panel = GameObject.Find("Panel");
        panel.SetActive(false);

        btnBegin = GameObject.Find("start").transform;
        btnSet = GameObject.Find("set").transform;
        btnHelp = GameObject.Find("help").transform;
        btnExit = GameObject.Find("exit").transform;
	}
	
	// Update is called once per frame
	void Update () {
        width = Screen.width;
        height = Screen.height;
        btnBegin.localPosition = new Vector3(0, 60, 0);
        btnSet.localPosition = new Vector3(0, 20, 0);
        btnHelp.localPosition = new Vector3(0, -20, 0);
        btnExit.localPosition = new Vector3(0, -60, 0);
        if (opt != Option.home)
        {

            panel.transform.position = new Vector3(width / 2, height / 2, 0);
            btnBack.transform.localPosition = new Vector3(width / 2 - 20, height / 2 - 20, 0);
            msgShow.transform.localPosition = new Vector3(width / 4 + 50, 0, 0);
            msgShow.transform.localScale = new Vector3(((float)width - 200) / 2 / 200, (float)height / 200, 1);
            btnLevel.transform.localPosition = new Vector3(-width / 2 + 100, height / 2 - 30, 0);
            btnWeapon.transform.localPosition = new Vector3(-width / 2 + 100, height / 2 - 70, 0);
            btnBullet.transform.localPosition = new Vector3(0, height / 2 - 30, 0);
            btnRay.transform.localPosition = new Vector3(0, height / 2 - 70, 0);
            //setupMsgPanel.transform.localPosition = new Vector3(0, 0, 0);
        }
	}

    public void OnStartClick()
    {
        GameStatement.gameStatement.gameLevel = 1;
        Application.LoadLevel("level1");
    }

    public void OnSetClick()
    {
        opt = Option.set;
        msgShow.SetActive(false);
        panel.SetActive(true);
        setupPanel.SetActive(true);
        OnChooseLevel();
    }

    public void OnHelpClick()
    {
        opt = Option.help;
        setupPanel.SetActive(false);
        panel.SetActive(true);
        msgShow.SetActive(true);
        //rectTransform.rect =new Rect(0, 0, 10,10);
        //    Screen.width / 2 - Screen.width / 6;
        //rectTransform.Right = -rectTransform.Left;
        msgShow.GetComponent<Text>().text = "帮助信息\nW:前进\nA:左移\nS:后退\nD:右移\n空格:跳跃\n鼠标左键:攻击\n\n作者:puyr\nE-mail:mazepuyr@163.com\n版本:1.01\n";
        //msgShow.SetActive(true);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnBackClick()
    {
        opt = Option.home;
        //msgShow.GetComponent<Text>().text = "";
        setupPanel.SetActive(false);
        msgShow.SetActive(false);
        panel.SetActive(false);
    }

    public void OnChooseLevel()
    {
        levelPanel.SetActive(true);
        weaponPanel.SetActive(false);
        if (!setLevelFlag)
        {
            btnLevel1.transform.localPosition = getLocalPosition(1);
            btnLevel1.GetComponent<Button>().onClick.AddListener(() => OnClickLevel(1));
            for (int i = 1; i < Application.levelCount - 2; i++)
            {
                GameObject newButton = Instantiate(btnLevel1, new Vector3(width / 2, height / 2, 0) + getLocalPosition(i + 1), btnLevel1.transform.rotation) as GameObject;
                newButton.transform.SetParent(levelPanel.transform);
                newButton.GetComponentInChildren<Text>().text = "" + (i + 1);
                newButton.name = "btnLevel" + (i + 1);
                int p = i + 1;
                newButton.GetComponent<Button>().onClick.AddListener(() => OnClickLevel(p));
            }
            btnLevel1.transform.SetParent(levelPanel.transform);
            setLevelFlag = true;
        }
    }

    private Vector3 getLocalPosition(int level)
    {
        float x = -width / 4 + 40 + 50 * ((level - 1) % (width / 2 / 50));
        float y = height / 2 - 40 - 50 * ((level - 1) / (width / 2 / 50));
        return new Vector3(x, y, 0);
    }

    public void OnClickLevel(int level)
    {
        GameStatement.levelStatementIsDone = false;
        Application.LoadLevel(level+1);
    }

    public void OnChooseWeapon()
    {
        weaponPanel.SetActive(true);
        levelPanel.SetActive(false);
        if (!setWeaponFlag)
        {
            setBullet();
            setWeaponFlag = true;
        }
    }

    public void setBullet()
    {
        ShooterControl.setWeapon(ShooterControl.WeaponNumber.Bullet);
        btnRay.GetComponent<Image>().color = new Color(1, 1, 1);
        btnBullet.GetComponent<Image>().color = new Color(122F / 255, 104F / 255, 167F / 255);
    }

    public void setRay()
    {
        ShooterControl.setWeapon(ShooterControl.WeaponNumber.Ray);
        btnBullet.GetComponent<Image>().color = new Color(1, 1, 1);
        btnRay.GetComponent<Image>().color = new Color(122F / 255, 104F / 255, 167F / 255);
    }
}
