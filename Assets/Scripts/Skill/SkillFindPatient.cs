using UnityEngine;
using System.Collections;

public class SkillFindPatient : MonoBehaviour {

    public SkillMove skillMove;
    public SkillFaceToPlayer skillFaceToPlayer;
    public SkillCure skillCure;

    public GameObject objFind;
    BaseStatement objFindStatement;
	// Use this for initialization
    void Awake()
    {
    }
	void Start () {
	
	}

    void OnEnable()
    {
        
    }

	// Update is called once per frame
	void Update () {
        if (objFind && objFind.activeSelf && objFindStatement && (objFindStatement.hp != objFindStatement.maxHp[objFindStatement.level])) 
        {
            return;
        }
        //EnemyPool.patientsLock.WaitOne();
        if (EnemyBaseStatement.patients.Count <= 0)
        {
            return;
        }
        objFind = EnemyBaseStatement.patients[Random.Range(0, EnemyBaseStatement.patients.Count)] as GameObject;
        //EnemyPool.patientsLock.ReleaseMutex();
        objFindStatement = objFind.GetComponent<BaseStatement>();
        setObj(objFind);
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
