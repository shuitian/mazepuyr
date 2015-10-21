using UnityEngine;
using System.Collections;

public class SkillFindPatient : MonoBehaviour {

    public SkillMove skillMove;
    public SkillFaceToPlayer skillFaceToPlayer;
    public SkillCure skillCure;

    public GameObject objFind;
    BaseStatement objFindStatement;

    void Awake()
    {
        skillMove = GetComponent<SkillMove>();
        skillFaceToPlayer = GetComponent<SkillFaceToPlayer>();
        skillCure = GetComponent<SkillCure>();
    }
    
	// Update is called once per frame
	void Update () {
        if (objFind && objFind.activeSelf && objFindStatement && (objFindStatement.hp != objFindStatement.maxHp[objFindStatement.level])) 
        {
            return;
        }
        if (SkillCure.patients.Count <= 0)
        {
            return;
        }
        objFind = SkillCure.patients[Random.Range(0, SkillCure.patients.Count)] as GameObject;
        if (objFind)
        {
            objFindStatement = objFind.GetComponent<BaseStatement>();
            setObj(objFind);
        }
        else
        {
            SkillCure.patients.Remove(objFind);
        }
	}

    void setObj(GameObject obj)
    {
        if (skillMove)
        {
            skillMove.setMoveTo(obj);
        }
        if (skillFaceToPlayer)
        {
            skillFaceToPlayer.setObjectFaceTo(obj);
        }
        if (skillCure)
        {
            skillCure.setPatient(obj);
        }
    }
}
