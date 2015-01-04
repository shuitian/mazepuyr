using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MinMapCameraSetting : MonoBehaviour {

    public Camera minMapCamera;
    public Rect rect;

    public Texture playerTexture;
    public Vector3 playerPosition;
    public Rect playerRect;
	// Use this for initialization
	void Start () {
        minMapCamera = GetComponent<Camera>();
        rect = minMapCamera.rect;
        rect.yMax = 0.3F;
	}
	
	// Update is called once per frame
	void Update () {
        rect.xMax = 0.3F * Screen.height / Screen.width;
        minMapCamera.rect = rect;
    }

    void OnGUI()
    {
        if (playerTexture == null && PlayerStatementShow.playerStatementShow != null)
        {
            playerTexture = PlayerStatementShow.playerStatementShow.headImage.GetComponent<RawImage>().texture;
        }
        if (PlayerBaseStatement.player != null)
        {
            playerPosition = PlayerBaseStatement.player.transform.position;
        }
        if (playerTexture == null || PlayerStatementShow.playerStatementShow == null || PlayerBaseStatement.player ==null)
        {
            return;
        }
        playerRect = new Rect(playerPosition.x / 2000 * Screen.width * rect.xMax - 5, Screen.height-playerPosition.z / 2000 * Screen.height * rect.yMax - 5, 10, 10);
        print(playerRect);
        GUI.DrawTexture(playerRect, playerTexture);//在屏幕上画出材质。
    }
}
