using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatementShow : MonoBehaviour {

    static public PlayerStatementShow playerStatementShow;
    public GameObject headImage;
    public GameObject levelText;
    public GameObject hpBar;
    public GameObject hpText;
    public GameObject mpBar;
    public GameObject mpText;
    public GameObject expBar;
    public GameObject expText;
	// Use this for initialization
	void Start () {
        playerStatementShow = GetComponent<PlayerStatementShow>();
        headImage = transform.Find("headImage").gameObject;
        levelText = transform.Find("headImage/levelText").gameObject;
        hpBar = transform.Find("hpBar").gameObject;
        hpText = transform.Find("hpBar/hpText").gameObject;
        mpBar = transform.Find("mpBar").gameObject;
        mpText = transform.Find("mpBar/mpText").gameObject;
        expBar = transform.Find("expBar").gameObject;
        expText = transform.Find("expBar/expText").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void updateHeadImage(Texture texture)
    {
        //print(headImage.GetComponent<Image>().sprite.packed);
        //headImage.GetComponent<Image>().sprite.texture = texture;
        //headImage.GetComponent<Image>().guiTexture.texture = texture;
    }

    public void updateLevelText(int level)
    {
        levelText.GetComponent<Text>().text = level + "";
    }

    public void updateHpText(float hp, float maxHp)
    {
        hpBar.GetComponent<Image>().fillAmount = (hp / maxHp);
        hpText.GetComponent<Text>().text = hp + "/" + maxHp;
    }

    public void updateMpText(float mp, float maxMp)
    {
        mpBar.GetComponent<Image>().fillAmount = (mp / maxMp);
        mpText.GetComponent<Text>().text = mp + "/" + maxMp;
    }

    public void updateExpText(float exp, float maxExp)
    {
        expBar.GetComponent<Image>().fillAmount = (exp / maxExp);
        expText.GetComponent<Text>().text = exp + "/" + maxExp;
    }

}
