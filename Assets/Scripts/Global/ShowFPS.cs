using UnityEngine;
using System.Collections;

public class ShowFPS : MonoBehaviour {

    float updateInterval = 1F;
    float timeleft = 0;
    int frames = 0;
    float accum = 0;
    public string FPS;
	
	// Update is called once per frame
	void Update () {
    	timeleft -= Time.deltaTime;
        accum += Time.timeScale/Time.deltaTime;
        ++frames;
        if( timeleft <= 0.0 )
        {
            FPS = (accum / frames).ToString("f2");
            timeleft = updateInterval;
            accum = 0.0F;
            frames = 0;
        }
    }
}
