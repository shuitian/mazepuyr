using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;

public class GUIPlayerStatementShow : MonoBehaviour
{

    static public GUIPlayerStatementShow playerStatementShow;
    public GameObject headImage;
    public GameObject levelText;
    public GameObject hpBar;
    public GameObject hpText;
    public GameObject mpBar;
    public GameObject mpText;
    public GameObject expBar;
    public GameObject expText;

    void Awake()
    {
        playerStatementShow = GetComponent<GUIPlayerStatementShow>();
        headImage = transform.Find("headImage").gameObject;
        levelText = transform.Find("headImage/levelText").gameObject;
        hpBar = transform.Find("hpBar").gameObject;
        hpText = transform.Find("hpBar/hpText").gameObject;
        mpBar = transform.Find("mpBar").gameObject;
        mpText = transform.Find("mpBar/mpText").gameObject;
        expBar = transform.Find("expBar").gameObject;
        expText = transform.Find("expBar/expText").gameObject;
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void updateHeadImage()//Texture texture)
    {
        //OpenFileName ofn = new OpenFileName();

        //ofn.structSize = Marshal.SizeOf(ofn);

        //ofn.filter = "图片文件(*.jpg*.png)\0*.jpg;*.png";

        //ofn.file = new string(new char[256]);

        //ofn.maxFile = ofn.file.Length;

        //ofn.fileTitle = new string(new char[64]);

        //ofn.maxFileTitle = ofn.fileTitle.Length;

        //ofn.initialDir = UnityEngine.Application.dataPath;//默认路径

        //ofn.title = "Open Project";

        //ofn.defExt = "JPG";//显示文件的类型
        ////注意 一下项目不一定要全选 但是0x00000008项不要缺少
        //ofn.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;//OFN_EXPLORER|OFN_FILEMUSTEXIST|OFN_PATHMUSTEXIST| OFN_ALLOWMULTISELECT|OFN_NOCHANGEDIR

        //if (WindowDll.GetOpenFileName(ofn))
        //{
        //    Debug.Log("Selected file with full path: {0}" + ofn.file);
        //}
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
