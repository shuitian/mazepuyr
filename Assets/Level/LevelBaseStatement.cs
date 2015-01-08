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
    protected LevelBaseStatement levelBaseStatement;

    public Vector3 bornPosition;
    public GameObject enemyGenerator;
    public GameObject FPC;
    public GameObject baseTerrain;
    public GameObject canvasGUI;
    public GameObject eventSystem;

    private int state = 0;

    public string info;
    public string levelTitle;
    public string levelIntroduction;

    // Use this for initialization
    protected void Awake()
    {
        enemyGenerator = new GameObject();
        enemyGenerator.name = "EnemyGenerator";
        enemyGenerator.tag = "EnemyGenerator";
    }

	// Use this for initialization
	protected void Start () {
        
	}
	
	// Update is called once per frame
	protected void Update () {
        if (state == 0 && !GameStatement.gameStatement.paused && GameStatement.beginGenereate)
        {
            state = checkGame();
            if (state == 1)
            {
                passLevel();
            }
            else if (state == -1)
            {
                loseLevel();
            }
        }
	}

    public int getState()
    {
        return state;
    }

    public virtual int checkGame()
    {
        return 0;
    }

    public virtual void passLevel()
    {        
       GUIMsgPanel.msgPanel.showWin();   
    }

    public virtual void loseLevel()
    {
        GUIMsgPanel.msgPanel.showLose();
    }

    public virtual void Refresh()
    {
        state = 0;
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
