using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIIntroductionShow : MonoBehaviour {

    public Animator animator;
    public GameObject btnStart;
    bool flag;
    void Awake()
    {
        btnStart = transform.Find("btnStart").gameObject;
        animator = GetComponent<Animator>();
        GetComponent<Text>().text = GameStatement.levelStatement.levelTitle;
        //animation.Play("LevelLoaded");
    }
    // Use this for initialization
    void Start()
    {
        btnStart.SetActive(false);
        flag = false;
        //animator.GetCurrentAnimationClipState(0)
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

    public void setLevelStatementDone()
    {
        GameStatement.levelStatementIsDone = true;
        //Time.timeScale = GameStatement.savedTimeScale;
        Screen.showCursor = false;
        Message.raiseOneMessage(new Message.LEVELISDONE(), this, new BaseEventArgs());
    }
}
