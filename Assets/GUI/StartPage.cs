using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartPage : MonoBehaviour {

    private GameObject setPanel;
        private GameObject msgShow;
            private GameObject setupMsgPanel;
                private GameObject levelPanel;
                private GameObject weaponPanel;
                    private Transform btnBullet;
                    private Transform btnRay;
            private Transform btnLevel;
            private Transform btnWeapon;
            private GameObject btnLevel1;
        private GameObject setupPanel;
        private Transform btnBack;
    
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

                        btnBullet = transform.Find("setPanel/setupPanel/setupMsgPanel/weaponPanel/btnBullet");
                        btnRay = transform.Find("setPanel/setupPanel/setupMsgPanel/weaponPanel/btnRay");
                        weaponPanel = GameObject.Find("StartPageCanvas/setPanel/setupPanel/setupMsgPanel/weaponPanel"); ;
                    levelPanel = GameObject.Find("StartPageCanvas/setPanel/setupPanel/setupMsgPanel/levelPanel");
                    setupMsgPanel = GameObject.Find("StartPageCanvas/setPanel/setupPanel/setupMsgPanel");
                btnLevel = transform.Find("setPanel/setupPanel/btnLevel");
                btnWeapon = transform.Find("setPanel/setupPanel/btnWeapon");
                btnLevel1 = GameObject.Find("StartPageCanvas/setPanel/setupPanel/btnLevel1");
            setupPanel = GameObject.Find("StartPageCanvas/setPanel/setupPanel");
            msgShow = GameObject.Find("StartPageCanvas/setPanel/msgShow");
            btnBack = transform.Find("setPanel/btnBack");
        setPanel = GameObject.Find("StartPageCanvas/setPanel"); ;
        setPanel.SetActive(false);
        width = Screen.width+1;
        height = Screen.height+1;
	}
	
	// Update is called once per frame
	void Update () {
        if (opt != Option.home)
        {
            if (width != Screen.width || height != Screen.height)
            {
                //panel.transform.position = new Vector3(width / 2, height / 2, 0);
                btnBack.transform.localPosition = new Vector3(width / 2 - 20, height / 2 - 20, 0);
                msgShow.transform.localPosition = new Vector3(width / 4 + 50, 0, 0);
                msgShow.transform.localScale = new Vector3(((float)width - 200) / 2 / 200, (float)height / 200, 1);
                btnLevel.transform.localPosition = new Vector3(-width / 2 + 100, height / 2 - 30, 0);
                btnWeapon.transform.localPosition = new Vector3(-width / 2 + 100, height / 2 - 70, 0);
                btnBullet.transform.localPosition = new Vector3(0, height / 2 - 30, 0);
                btnRay.transform.localPosition = new Vector3(0, height / 2 - 70, 0);
                //setupMsgPanel.transform.localPosition = new Vector3(0, 0, 0);
                width = Screen.width;
                height = Screen.height;
            }
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
        setPanel.SetActive(true);
        msgShow.SetActive(false);
        setupPanel.SetActive(true);
        OnChooseLevel();
    }

    public void OnHelpClick()
    {
        opt = Option.help;
        setPanel.SetActive(true);
        setupPanel.SetActive(false);
        msgShow.SetActive(true);
        msgShow.GetComponent<Text>().text = "\n帮助信息\nESC:暂停\nW:前进\tA:左移\nS:后退\tD:右移\n空格:跳跃\t鼠标左键:攻击\n\n作者:puyr\nE-mail:mazepuyr@163.com\n版本:1.03\n";
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnBackClick()
    {
        opt = Option.home;
        setPanel.SetActive(false);
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
            if (ShooterControl.weaponNumber == ShooterControl.WeaponNumber.Ray)
            {
                setRay();
            }
            else
            {
                setBullet();
            }
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
