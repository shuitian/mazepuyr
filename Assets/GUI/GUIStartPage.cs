using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text;

public class GUIStartPage : MonoBehaviour
{

    public GameObject setPanel;
    public GameObject setupPanel;
    public GameObject setupMsgPanel;
    public GameObject levelPanel;
        public GameObject btnLevel1;
    public GameObject weaponPanel;
        public Image btnBulletImage;
        public Image btnRayImage;
        public Image btnBulletStoneSpearImage;
    public GameObject msgShow;
    public Text msgShowText;

    private bool setLevelFlag;

    public Color chosenColor;
    public Color notChosenColor;
	// Use this for initialization
	void Start () {
        setLevelFlag = false;
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
        msgShowText.text = GameStatement.helpInfo;
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
        if (WeaponNumber.weaponNumber == WeaponNumber.Weapon.Ray)
        {
            setRay();
        }
        else if (WeaponNumber.weaponNumber == WeaponNumber.Weapon.BulletStoneSpear)
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
        WeaponNumber.setWeapon(WeaponNumber.Weapon.Bullet);
            btnBulletImage.color = chosenColor;
        btnRayImage.color = notChosenColor;
        btnBulletStoneSpearImage.color = notChosenColor;
    }

    public void setRay()
    {
        WeaponNumber.setWeapon(WeaponNumber.Weapon.Ray);
        btnBulletImage.color = notChosenColor;
            btnRayImage.color = chosenColor;
        btnBulletStoneSpearImage.color = notChosenColor;
        
    }

    public void setBulletStoneSpear()
    {
        WeaponNumber.setWeapon(WeaponNumber.Weapon.BulletStoneSpear);
        btnBulletImage.color = notChosenColor;
        btnRayImage.color = notChosenColor;
            btnBulletStoneSpearImage.color = chosenColor;
    }
}
