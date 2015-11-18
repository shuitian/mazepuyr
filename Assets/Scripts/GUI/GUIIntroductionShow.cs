using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityTool.Libgame;

public class GUIIntroductionShow : MonoBehaviour {

    public Animator animator;
    public GameObject btnStart;
    public Text text;
    bool flag;
    void Awake()
    {
        Cursor.visible = true;
        text.text = LevelBaseStatement.levelBaseStatement.levelTitle;
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
        if (!flag && !LevelBaseStatement.levelStatementIsDone)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.Dead"))
            {
                text.text = LevelBaseStatement.levelBaseStatement.levelIntroduction;
                btnStart.SetActive(true);
                flag = true;
            }
        }
    }

    public void setLevelStatementDone()
    {
        //StateMachine.ChangeState("LevelState", "Running");
        LevelBaseStatement.levelStatementIsDone = true;
        Cursor.visible = false;
        Message.RaiseOneMessage<string>("LevelIsDone", this, "");
    }
}
