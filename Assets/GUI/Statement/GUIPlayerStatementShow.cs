using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;

public class GUIPlayerStatementShow : MonoBehaviour
{

    static public GUIPlayerStatementShow playerStatementShow;
    public RawImage headImage;
    public Text levelText;
    public Image hpBar;
    public Text hpText;
    public Image mpBar;
    public Text mpText;
    public Image expBar;
    public Text expText;

    void Awake()
    {
        playerStatementShow = GetComponent<GUIPlayerStatementShow>();
        headImage = transform.Find("headImage").GetComponent<RawImage>();
        levelText = transform.Find("headImage/levelText").GetComponent<Text>();
        hpBar = transform.Find("hpBar").GetComponent<Image>();
        hpText = transform.Find("hpBar/hpText").GetComponent<Text>();
        mpBar = transform.Find("mpBar").GetComponent<Image>();
        mpText = transform.Find("mpBar/mpText").GetComponent<Text>();
        expBar = transform.Find("expBar").GetComponent<Image>();
        expText = transform.Find("expBar/expText").GetComponent<Text>();
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
        levelText.text = level + "";
    }

    public void updateHpText(float hp, float maxHp)
    {
        hpBar.fillAmount = (hp / maxHp);
        hpText.text = hp + "/" + maxHp;
    }

    public void updateMpText(float mp, float maxMp)
    {
        mpBar.fillAmount = (mp / maxMp);
        mpText.text = mp + "/" + maxMp;
    }

    public void updateExpText(float exp, float maxExp)
    {
        expBar.fillAmount = (exp / maxExp);
        expText.text = exp + "/" + maxExp;
    }

}
