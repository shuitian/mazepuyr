using UnityEngine;
using System.Collections;
using UnityTool.Libgame;
public class Test : TestEvent
{
	
	// Update is called once per frame
	void Update () {
        //f();
        Message.RaiseOneMessage<string>("Test", this, "e");
	}
}
