using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIIntroductionShow : MonoBehaviour {

    public Animator animator;
    public GameObject btnStart;
    bool flag;
    void Awake()
    {
        Screen.showCursor = true;
        btnStart = transform.Find("btnStart").gameObject;
        animator = GetComponent<Animator>();
        GetComponent<Text>().text = GameStatement.levelStatement.levelTitle;
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
                GetComponent<Text>().text = GameStatement.levelStatement.levelIntroduction;
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
        Screen.showCursor = false;
        Message.raiseOneMessage(new Message.LEVELISDONE(), this, new BaseEventArgs());
    }
}
