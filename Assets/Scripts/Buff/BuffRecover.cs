using UnityEngine;
using System.Collections;
using System;

public class BuffRecover : MonoBehaviour {

    public BaseStatement doctor;
    public BaseStatement toBeRecovered;
    public float recover = 1;
    public int time = 1;
    public float recoverPerSecond { get { return recover / time; } }

    void OnDisable()
    {
        Destroy(this);
    }

    IEnumerator Recover()
    {
        while (true)
        {
            toBeRecovered.recoverHp(recoverPerSecond * Time.deltaTime);
            yield return 0;
        }
    }

    IEnumerator WaitForDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this);
    }

    public void StartRecover()
    {
        if (!toBeRecovered)
        {
            return;
        }
        if (time < 1)
        {
            time = 1;
        }
        if (gameObject.activeSelf)
        {
            StartCoroutine(Recover());
            StartCoroutine(WaitForDestroy(time));
        }
    }
}
