using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelBaseStatement : MonoBehaviour {

    public int terrainMinX = 0;
    public int terrainMaxX = 2000;
    public int terrainMinY = 0;
    public int terrainMaxY = 2000;
    public int terrainMinZ = 0;
    public int terrainMaxZ = 2000;
    public int maxEnemiesNumber;
    public string info;
    protected LevelBaseStatement levelBaseStatement;
    public Vector3 bornPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //public virtual void showInfo()
    //{
    //    GameObject.Find("CanvasGUI/infoPanel/levelInfoText").GetComponent<Text>().text = info;
    //}

    public virtual Vector3 getBornPosition()
    {
        return bornPosition;
    }

    public virtual void setBornPosition(Vector3 bornPosition)
    {
        this.bornPosition = bornPosition;
    }

    public virtual LevelBaseStatement getLevelBaseStatement()
    {
        return levelBaseStatement;
    }

    public virtual void setLevelBaseStatement(LevelBaseStatement levelBaseStatement)
    {
        this.levelBaseStatement = levelBaseStatement;
    }
}
