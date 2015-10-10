using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;
using Regame;

public class GUIPlayerStatementShow : MonoBehaviour
{
    public static GUIPlayerStatementShow playerStatementShow;
    public Texture headTexture 
    {
        get 
        {
            if (headImage)
            {
                return headImage.texture;
            }
            return null;
        } 
    }
    public RawImage headImage;
    public Text levelText;
    public Image hpBar;
    public Text hpText;
    public Image mpBar;
    public Text mpText;
    public Image expBar;
    public Text expText;

    protected void Awake()
    {
        playerStatementShow = this;
        Message.RegeditMessageHandle<int>("UpdatePlayerLevelText", updateLevelText);
        Message.RegeditMessageHandle<float[]>("UpdatePlayerHpText", updateHpText);
        Message.RegeditMessageHandle<float[]>("UpdatePlayerMpText", updateMpText);
        Message.RegeditMessageHandle<float[]>("UpdatePlayerExpText", updateExpText);
    }

    protected void OnDestroy()
    {
        Message.UnregeditMessageHandle<int>("UpdatePlayerLevelText", updateLevelText);
        Message.UnregeditMessageHandle<float[]>("UpdatePlayerHpText", updateHpText);
        Message.UnregeditMessageHandle<float[]>("UpdatePlayerMpText", updateMpText);
        Message.UnregeditMessageHandle<float[]>("UpdatePlayerExpText", updateExpText);

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

    protected void updateLevelText(string messageName, object sender, int level)
    {
        if (levelText)
        {
            levelText.text = level + "";
        }
    }

    protected void updateHpText(string messageName, object sender, float[] hps)
    {
        if (hpBar)
        {
            hpBar.fillAmount = (hps[0] / hps[1]);
        }
        if (hpText)
        {
            hpText.text = hps[0] + "/" + hps[1];
        }
    }

    protected void updateMpText(string messageName, object sender, float[] mps)
    {
        if (mpBar)
        {
            mpBar.fillAmount = (mps[0] / mps[1]);
        }
        if (mpText)
        {
            mpText.text = mps[0] + "/" + mps[1];
        }
    }

    protected void updateExpText(string messageName, object sender, float[] exps)
    {
        if (expBar)
        {
            expBar.fillAmount = (exps[0] / exps[1]);
        }
        if (expText)
        {
            expText.text = exps[0] + "/" + exps[1];
        }
    }
}
