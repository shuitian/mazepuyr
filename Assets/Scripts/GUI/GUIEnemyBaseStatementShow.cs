using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GUIEnemyBaseStatementShow : MonoBehaviour
{
    public Text nameText;
    public Image hpBar;
    public Text hpText;
    public Image mpBar;
    public Text mpText;
    public Image expBar;
    public Text expText;
    public Text levelText;

    // Use this for initialization
    void Start()//try-catch
    {        
    }

    // Update is called once per frame
    void Update()
    {
        
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
