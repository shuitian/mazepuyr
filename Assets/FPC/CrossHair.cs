using UnityEngine;
using System.Collections;

public class CrossHair : MonoBehaviour {

    public Texture2D crossHairTexture;
    public Rect position;
	// Use this for initialization
	void Start () {
        //Input.mousePosition.x
        //    Input.mousePosition.y
        //print(Input.mousePosition);
        //position = new Rect(Input.mousePosition.x - 25, Screen.height - Input.mousePosition.y - 25, 50, 50);
        Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
        //print(Input.mousePosition);
        position = new Rect(Input.mousePosition.x - 25, Screen.height - Input.mousePosition.y - 25, 50, 50);
    }

    void OnGUI()
        
    {
        GUI.DrawTexture(position, crossHairTexture);//在屏幕上画出材质。
    }
}
