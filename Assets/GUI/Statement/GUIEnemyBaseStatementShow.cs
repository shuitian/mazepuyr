using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GUIEnemyBaseStatementShow : MonoBehaviour
{
    //static public PlayerStatementShow playerStatementShow;
    public Text nameText;
    public Image hpBar;
    public Text hpText;
    public Image mpBar;
    public Text mpText;
    public Image expBar;
    public Text expText;
    public Text levelText;

    public Transform body;
    void Awake()
    {
        nameText = transform.Find("statePanel/nameText").gameObject.GetComponent<Text>();
        hpBar = transform.Find("statePanel/hpBar").gameObject.GetComponent<Image>();
        hpText = transform.Find("statePanel/hpBar/hpText").gameObject.GetComponent<Text>();
        mpBar = transform.Find("statePanel/mpBar").gameObject.GetComponent<Image>();
        mpText = transform.Find("statePanel/mpBar/mpText").gameObject.GetComponent<Text>();
        expBar = transform.Find("statePanel/expBar").gameObject.GetComponent<Image>();
        expText = transform.Find("statePanel/expBar/expText").gameObject.GetComponent<Text>();
        levelText = transform.Find("statePanel/expBar/levelText").gameObject.GetComponent<Text>();
        body = transform.parent.gameObject.GetComponentInChildren<ShowPosition>().transform;
    }

    // Use this for initialization
    void Start()//try-catch
    {        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = body.position + new Vector3(0, body.lossyScale.y, 0);
    }

    public void updateNameText(string name)
    {
        try
        {
            nameText.text = name;
        }
        catch (Exception e)
        {
            print("EnemyBaseStatementShow: updateName\t"+e);
        }
    }

    public void updateHpText(float hp, float maxHp)
    {
        try
        {
            hpBar.fillAmount = (hp / maxHp);
            hpText.text = hp + "/" + maxHp;
        }
        catch (Exception e)
        {
            print("EnemyBaseStatementShow: updateHpText\t" + e);
        }
    }

    public void updateMpText(float mp, float maxMp)
    {
        try
        {
            mpBar.fillAmount = (mp / maxMp);
            mpText.text = mp + "/" + maxMp;
        }
        catch (Exception e)
        {
            print("EnemyBaseStatementShow: updateMpText\t" + e);
        }
    }

    public void updateExpText(float exp, float maxExp)
    {
        try
        {
            expBar.fillAmount = (exp / maxExp);
            expText.text = exp + "/" + maxExp;
        }
        catch (Exception e)
        {
            print("EnemyBaseStatementShow: updateExpText\t" + e);
        }
    }

    public void updateLevelText(int level)
    {
        try
        {
            levelText.text = ""+level;
        }
        catch (Exception e)
        {
            print("EnemyBaseStatementShow: updateLevelText\t" + e);
        }
    }
}
