using UnityEngine;
using System.Collections;
using Regame;

public class ShowFPS : MonoBehaviour {

    public string FPS;
	
	// Update is called once per frame
	void Update () {
        FPS = Regame.FPS.GetFPS(.5F);
    }
}
