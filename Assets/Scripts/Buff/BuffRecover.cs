using UnityEngine;
using System.Collections;

//[System.Serializable]
public class BuffRecover : MonoBehaviour {

    public BaseStatement doctor;
    public BaseStatement toBeRecovered;
    public float recover = 1;
    public int time = 1;
    float hasRecovered;
    float lastRecoverTime;
    float enableTime;
    bool started = false;

	// Update is called once per frame
	void Update () {
        if (!toBeRecovered || !started)
        {
            return;
        }
        float t=Time.time;
        if (hasRecovered < recover && t > lastRecoverTime + 1)
        {
            float actualRecover = toBeRecovered.recoverHp(recover / time);
            hasRecovered += actualRecover;
            doctor.getExp(toBeRecovered, actualRecover / recover);
            lastRecoverTime = t;
        }
        if (Time.time >= enableTime + time) 
        {
            Destroy(this);
        }
	}

    public void startRecover()
    {
        enableTime = Time.time;
        lastRecoverTime = Time.time;
        hasRecovered = 0;
        if (time < 1)
        {
            time = 1;
        }
        started = true;
    }
}
