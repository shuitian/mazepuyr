using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Regame;

public class GUIIntroductionShow : MonoBehaviour {

    public Animator animator;
    public GameObject btnStart;
    public Text text;
    bool flag;
    void Awake()
    {
        Cursor.visible = true;
        text.text = GameStatement.levelStatement.levelTitle;
    }
    // Use this for initialization
    void Start()
    {
        btnStart.SetActive(false);
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!flag && !GameStatement.levelStatementIsDone)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.nameHash == Animator.StringToHash("Base Layer.Dead"))
            {
                text.text = GameStatement.levelStatement.levelIntroduction;
                btnStart.SetActive(true);
                flag = true;
            }
        }
    }

    public void setEasy()
    {
        GameStatement.Difficult = 1;
        setLevelStatementDone();
    }

    public void setNormal()
    {
        GameStatement.Difficult = 2;
        setLevelStatementDone();
    }

    public void setHard()
    {
        GameStatement.Difficult = 3;
        setLevelStatementDone();
    }

    public void setLevelStatementDone()
    {
        GameStatement.levelStatementIsDone = true;
        Cursor.visible = false;
        Message.RaiseOneMessage<string>("LevelIsDone", this, "");
    }
}
