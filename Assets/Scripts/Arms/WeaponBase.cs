using UnityEngine;
using System.Collections;

public class WeaponBase : MonoBehaviour {

    public BaseStatement shooterStatement;
    public WeaponNumber.Weapon number;
    public GameObject bullet;

    public float shootTimePerSecond = 10;
    protected float lastShootTime = 0;
    protected Ray ray;

    public Texture2D crossHairTexture;
    protected Rect crossHairPosition;
    public int crossHairSize;
	
	// Update is called once per frame
	void Update () {
        crossHairPosition = new Rect(Screen.width / 2 - crossHairSize / 2, Screen.height / 2 - crossHairSize / 2, crossHairSize, crossHairSize);
        if (!GameStatement.levelStatementIsDone)
        {
            return;
        }
        if (checkShootInput())
        {
            shoot();
        }
	}

    public virtual bool shoot()
    {
        if (Time.time - lastShootTime < 1 / shootTimePerSecond)
        {
            return false;
        }
        lastShootTime = lastShootTime + 1 / shootTimePerSecond;
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        return true;
    }

    public virtual bool checkShootInput()
    {
        if (Input.GetMouseButton(0))
        {
            return true;
        }
        return false;
    }

    void OnGUI()
    {
        if (!GameStatement.levelStatementIsDone || crossHairTexture == null)
        {
            return;
        }
        GUI.DrawTexture(crossHairPosition, crossHairTexture);//在屏幕上画出材质。
    }

}
