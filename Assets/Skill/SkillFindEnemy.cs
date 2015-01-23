using UnityEngine;
using System.Collections;

public class SkillFindEnemy : MonoBehaviour {

    public SkillMove skillMove;
    public SkillAttack skillAttack;
    public SkillThrowSpear skillThrowSpear;
    public SkillFaceToPlayer skillFaceToPlayer;

    public GameObject objFind;
    public GameObject[] objsFind;
    public string[] tag = {"Enemy"};
    int tagLength;
    int i = 0;

	void Start () {
        tagLength = tag.Length;

        i = 0;
        objsFind = GameObject.FindGameObjectsWithTag(tag[i]);
	}
	
	// Update is called once per frame
	void Update () {
        if (objFind && objFind.activeSelf)
        {
            return;
        }
        foreach (GameObject step in objsFind)
        {
            GameObject obj = objsFind[Random.Range(0, objsFind.Length)];
            if (obj && obj.activeSelf)
            {
                objFind = obj;
                setObj(objFind);
                return;
            }
        }
        objsFind = GameObject.FindGameObjectsWithTag(tag[(++i)%tagLength]);
	}

    void setObj(GameObject obj)
    {
        if (skillMove)
        {
            skillMove.setMoveTo(obj);
        }
        if (skillAttack)
        {
            skillAttack.setToBeAttacked(obj);
        }
        if (skillThrowSpear)
        {
            skillThrowSpear.setToBeAttacked(obj);
        }
        if (skillFaceToPlayer)
        {
            skillFaceToPlayer.setObjectFaceTo(obj);
        }
    }
}
