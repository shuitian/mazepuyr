using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text;

public class GUIStartPage : MonoBehaviour
{

    public GameObject setPanel;
    public GameObject msgShow;
    public GameObject setupMsgPanel;
    public GameObject levelPanel;
    public GameObject weaponPanel;
    public Transform btnBullet;
    public Transform btnRay;
    public Transform btnBulletStoneSpear;
    public GameObject btnLevel1;
    public GameObject setupPanel;

    int width;
    int height;
    private bool setLevelFlag;
    //static private bool setWeaponFlag;

	// Use this for initialization
	void Start () {

        setLevelFlag = false;
        //setWeaponFlag = false;

        //                btnBullet = transform.Find("setPanel/setupPanel/setupMsgPanel/weaponPanel/btnBullet");
        //                btnRay = transform.Find("setPanel/setupPanel/setupMsgPanel/weaponPanel/btnRay");
        //                btnBulletStoneSpear = transform.Find("setPanel/setupPanel/setupMsgPanel/weaponPanel/btnBulletStoneSpear");
        //            weaponPanel = GameObject.Find("StartPageCanvas/setPanel/setupPanel/setupMsgPanel/weaponPanel"); ;
        //            levelPanel = GameObject.Find("StartPageCanvas/setPanel/setupPanel/setupMsgPanel/levelPanel");
        //            //setupMsgPanel = GameObject.Find("StartPageCanvas/setPanel/setupPanel/setupMsgPanel");
        //        //btnLevel = transform.Find("setPanel/setupPanel/btnLevel");
        //        //btnWeapon = transform.Find("setPanel/setupPanel/btnWeapon");
        //        //btnLevel1 = GameObject.Find("StartPageCanvas/setPanel/setupPanel/setupMsgPanel/levelPanel/LevelButton");
        btnLevel1 = Resources.Load("Prefab/LevelButton") as GameObject;
        //        //btnLevel1.transform.SetParent(levelPanel.transform);
        //    setupPanel = GameObject.Find("StartPageCanvas/setPanel/setupPanel");
        //    msgShow = GameObject.Find("StartPageCanvas/setPanel/msgShow");
        //    //btnBack = transform.Find("setPanel/btnBack");
        //setPanel = GameObject.Find("StartPageCanvas/setPanel"); ;
        setPanel.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBackClick();
        }
	}

    public void OnStartClick()
    {
        GameStatement.gameStatement.gameLevel = 1;
        GameStatement.levelStatementIsDone = false;
        Application.LoadLevel("level1");
    }

    public void OnSetClick()
    {
        setPanel.SetActive(true);
        msgShow.SetActive(false);
        setupPanel.SetActive(true);
        OnChooseLevel();
    }

    public void OnHelpClick()
    {
        setPanel.SetActive(true);
        setupPanel.SetActive(false);
        msgShow.SetActive(true);
        msgShow.GetComponent<Text>().text = GameStatement.helpInfo;
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnBackClick()
    {
        setPanel.SetActive(false);
    }

    public void OnChooseLevel()
    {
        levelPanel.SetActive(true);
        weaponPanel.SetActive(false);
        if (!setLevelFlag)
        {
            for (int i = 1; i < Application.levelCount - 1; i++)
            {
                GameObject newButton = Instantiate(btnLevel1, Vector3.zero, btnLevel1.transform.rotation) as GameObject;
                newButton.transform.SetParent(levelPanel.transform);
                newButton.transform.localPosition = getLocalPosition(i);
                newButton.GetComponentInChildren<Text>().text = "" + (i)+"  "+GameStatement.LevelTitle[i];
                newButton.name = "btnLevel" + (i);
                int p = i;
                newButton.GetComponent<Button>().onClick.AddListener(() => OnClickLevel(p));
            }
            setLevelFlag = true;
        }
    }

    private Vector3 getLocalPosition(int level)
    {
        float y = Screen.height/2 -(level - 1) * 40 - 25;
        return new Vector3(0, y, 0);
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
        if (BulletShooterControl.weaponNumber == BulletShooterControl.WeaponNumber.Ray)
        {
            setRay();
        }
        else if (BulletShooterControl.weaponNumber == BulletShooterControl.WeaponNumber.BulletStoneSpear)
        {
            setBulletStoneSpear();
        }
        else
        {
            setBullet();
        }
    }

    public void setBullet()
    {
        BulletShooterControl.setWeapon(BulletShooterControl.WeaponNumber.Bullet);
        btnRay.GetComponent<Image>().color = new Color(1, 1, 1);
        btnBulletStoneSpear.GetComponent<Image>().color = new Color(1, 1, 1);
        btnBullet.GetComponent<Image>().color = new Color(122F / 255, 104F / 255, 167F / 255);
    }

    public void setRay()
    {
        BulletShooterControl.setWeapon(BulletShooterControl.WeaponNumber.Ray);
        btnBullet.GetComponent<Image>().color = new Color(1, 1, 1);
        btnBulletStoneSpear.GetComponent<Image>().color = new Color(1, 1, 1);
        btnRay.GetComponent<Image>().color = new Color(122F / 255, 104F / 255, 167F / 255);
    }

    public void setBulletStoneSpear()
    {
        BulletShooterControl.setWeapon(BulletShooterControl.WeaponNumber.BulletStoneSpear);
        btnRay.GetComponent<Image>().color = new Color(1, 1, 1);
        btnBullet.GetComponent<Image>().color = new Color(1, 1, 1);
        btnBulletStoneSpear.GetComponent<Image>().color = new Color(122F / 255, 104F / 255, 167F / 255);
    }
}
