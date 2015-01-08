using UnityEngine;
using System.Collections;

public class BulletCrossHair : MonoBehaviour
{

    public Texture2D crossHairTexture;
    public Rect position;
    int size;
	// Use this for initialization
	void Start () {
        //Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
        //position = new Rect(Input.mousePosition.x - 25, Screen.height - Input.mousePosition.y - 25, 50, 50);
        size = 100;
        position = new Rect(Screen.width / 2 - size / 2, Screen.height / 2 - size / 2, size, size);
    }

    void OnGUI()
    {
        if (!GameStatement.levelStatementIsDone)
        {
            return;
        }
        if (crossHairTexture == null)
        {
            return;
        }
        GUI.DrawTexture(position, crossHairTexture);//在屏幕上画出材质。
    }
}
