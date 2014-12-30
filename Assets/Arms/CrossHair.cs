using UnityEngine;
using System.Collections;

public class CrossHair : MonoBehaviour {

    public Texture2D crossHairTexture;
    public Rect position;
	// Use this for initialization
	void Start () {
        Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
        //position = new Rect(Input.mousePosition.x - 25, Screen.height - Input.mousePosition.y - 25, 50, 50);
        position = new Rect(Screen.width/2 - 25, Screen.height/2 - 25, 50, 50);
    }

    void OnGUI()
    {
        if (crossHairTexture == null)
        {
            return;
        }
        GUI.DrawTexture(position, crossHairTexture);//在屏幕上画出材质。
    }
}
