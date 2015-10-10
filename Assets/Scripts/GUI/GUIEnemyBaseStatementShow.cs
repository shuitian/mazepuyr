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

    public void updateNameText(string name)
    {
        if (nameText)
        {
            nameText.text = name;
        }
    }

    public void updateHpText(float hp, float maxHp)
    {
        if(hpBar)
        {
            hpBar.fillAmount = (hp / maxHp);
        }
        if (hpText)
        {
            hpText.text = hp + "/" + maxHp;
        }
    }

    public void updateMpText(float mp, float maxMp)
    {
        if (mpBar)
        {
            mpBar.fillAmount = (mp / maxMp);
        }
        if (mpText)
        {
            mpText.text = mp + "/" + maxMp;
        }
    }

    public void updateExpText(float exp, float maxExp)
    {
        if (expBar)
        {
            expBar.fillAmount = (exp / maxExp);
        }
        if (expText)
        {
            expText.text = exp + "/" + maxExp;
        }
    }

    public void updateLevelText(int level)
    {
        if(levelText)
        {
            levelText.text = ""+level;
        }
    }
}
