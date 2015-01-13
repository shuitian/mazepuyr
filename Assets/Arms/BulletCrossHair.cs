using UnityEngine;
using System.Collections;

public class BulletCrossHair : MonoBehaviour
{

    public Texture2D crossHairTexture;
    public Rect position;
    int size;
	// Use this for initialization
	void Start () {
        size = 100;
	}
	
	// Update is called once per frame
	void Update () {
        position = new Rect(Screen.width / 2 - size / 2, Screen.height / 2 - size / 2, size, size);
    }

    void OnGUI()
    {
        if (!GameStatement.levelStatementIsDone || crossHairTexture == null)
        {
            return;
        }
        GUI.DrawTexture(position, crossHairTexture);//在屏幕上画出材质。
    }
}
