using UnityEngine;
using System.Collections;

public class SkillCure : MonoBehaviour {

    public GameObject patient;
    public GameObject doctor;

    public BaseStatement patientStatement;
    public BaseStatement doctorStatement;

    public int checkDistFrames = 10;
    public float cureDistance = 50;
    public float cureTimePerSecond = 1;
    public float recoverHp = 0;
    public float costMp = 0;

    protected bool inDistance;
    protected float lastCureTime = 0;
    int i;
    protected void Awake()
    {
    }
	// Use this for initialization
    protected void Start()
    {
	}

    protected void OnEnable()
    {
        i = 0;
    }

    protected void FixedUpdate()
    {
        if (!patient || !patientStatement || !doctor || !doctorStatement) 
        {
            return;
        }
        if (i++ > checkDistFrames)
        {
            i = 0;
            float dist = Vector3.Distance(patient.transform.position, doctor.transform.position);
            if (dist < cureDistance)
            {
                inDistance = true;
            }
            else
            {
                inDistance = false;
            }
        }
    }

	// Update is called once per frame
    protected void Update()
    {
        if (inDistance)
        {
            if (Time.time - lastCureTime > 1 / cureTimePerSecond)
            {
                if (patientStatement.hp < patientStatement.maxHp[patientStatement.level])
                {
                    cure(patientStatement);
                    lastCureTime = Time.time;
                }
            }
        }
	}

    public void cure(BaseStatement patientStatement)
    {
        if (doctorStatement.loseMp(costMp))
        {
            patientStatement.recoverHp(recoverHp);
        }
    }

    public void setPatient(GameObject patient)
    {
        this.patient = patient;
        patientStatement = patient.GetComponent<BaseStatement>();
    }
}
