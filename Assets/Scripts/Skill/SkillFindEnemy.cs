using UnityEngine;
using System.Collections;

public class SkillFindEnemy : MonoBehaviour {

    public SkillMove skillMove;
    public SkillAttack skillAttack;
    public SkillFaceToPlayer skillFaceToPlayer;

    public GameObject objFind;
    public GameObject[] objsFind;
    public string[] tags = {"Enemy"};

    void Awake()
    {
        skillMove = GetComponent<SkillMove>();
        skillAttack = GetComponent<SkillAttack>();
        skillFaceToPlayer = GetComponent<SkillFaceToPlayer>();
    }

    void OnEnable()
    {
        objsFind = GameObject.FindGameObjectsWithTag(tags[0]);
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
        objsFind = GameObject.FindGameObjectsWithTag(tags[Random.Range(0, tags.Length)]);
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
        if (skillFaceToPlayer)
        {
            skillFaceToPlayer.setObjectFaceTo(obj);
        }
    }
}