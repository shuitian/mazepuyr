using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class EnemyBaseStatementShow : MonoBehaviour {
    //static public PlayerStatementShow playerStatementShow;
    public GameObject nameText;
    public GameObject hpBar;
    public GameObject hpText;
    public GameObject mpBar;
    public GameObject mpText;
    // Use this for initialization
    void Start()//try-catch
    {
        //nameText = transform.Find("statePanel/nameText").gameObject;
        //hpBar = transform.Find("statePanel/hpBar").gameObject;
        //hpText = transform.Find("statePanel/hpBar/hpText").gameObject;
        //mpBar = transform.Find("statePanel/mpBar").gameObject;
        //mpText = transform.Find("statePanel/mpBar/mpText").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v;
        try
        {
            Transform t = transform.parent.gameObject.GetComponentInChildren<ShowPosition>().getTransform();
            transform.position = t.position + new Vector3(0,  t.parent.localScale.y * t.localScale.y, 0);
            v = PlayerBaseStatement.player.transform.position - transform.position;
        }
        catch (Exception e)
        {
            v = Vector3.zero - transform.position;
        }
        //transform.eulerAngles = v;
    }

    public void updateNameText(string name)
    {
        try
        {
            nameText.GetComponent<Text>().text = name;
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
            hpBar.GetComponent<Image>().fillAmount = (hp / maxHp);
            hpText.GetComponent<Text>().text = hp + "/" + maxHp;
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
            mpBar.GetComponent<Image>().fillAmount = (mp / maxMp);
            mpText.GetComponent<Text>().text = mp + "/" + maxMp;
        }
        catch (Exception e)
        {
            print("EnemyBaseStatementShow: updateMpText\t" + e);
        }
    }
}
