using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GUIMinMapCameraSetting : MonoBehaviour
{

    public Camera minMapCamera;
    public Rect rect;

    public Texture playerTexture;
    public Vector3 playerPosition;
    public Rect playerRect;
    int playerSize;
	// Use this for initialization
	void Start () {
        minMapCamera = GetComponent<Camera>();
        rect = minMapCamera.rect;
        rect.yMax = 0.4F;
        playerSize = 20;
	}
	
	// Update is called once per frame
	void Update () {
        rect.xMax = rect.yMax * Screen.height / Screen.width;
        minMapCamera.rect = rect;
    }

    void OnGUI()
    {
        if (!GameStatement.levelStatementIsDone)
        {
            return;
        }
        if (playerTexture == null && GUIPlayerStatementShow.playerStatementShow != null)
        {
            playerTexture = GUIPlayerStatementShow.playerStatementShow.headImage.texture;
        }
        if (PlayerBaseStatement.player != null)
        {
            playerPosition = PlayerBaseStatement.player.transform.position;
        }
        if (playerTexture == null || GUIPlayerStatementShow.playerStatementShow == null || PlayerBaseStatement.player == null)
        {
            return;
        }
        playerRect = new Rect(playerPosition.x / 2000 * Screen.width * rect.xMax - playerSize / 2, Screen.height - playerPosition.z / 2000 * Screen.height * rect.yMax - playerSize / 2, playerSize, playerSize);

        GUI.DrawTexture(playerRect, playerTexture);//在屏幕上画出材质。
    }
}
