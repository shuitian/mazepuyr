using UnityEngine;
using System.Collections;
using Regame;
public class Test : TestEvent
{
	
	// Update is called once per frame
	void Update () {
        //f();
        Message.RaiseOneMessage<string>("Test", this, "e");
	}
}
