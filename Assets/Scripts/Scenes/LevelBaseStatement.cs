using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Regame;
public class LevelBaseStatement : MonoBehaviour {

    public int terrainMinX = 0;
    public int terrainMaxX = 2000;
    public int terrainMinY = 0;
    public int terrainMaxY = 2000;
    public int terrainMinZ = 0;
    public int terrainMaxZ = 2000;

    protected int enemiesNumber;
    public int maxEnemiesNumber = 0;
    public static  LevelBaseStatement levelBaseStatement;

    public Vector3 bornPosition;
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
        levelBaseStatement = this;
    }

	// Use this for initialization
	protected void Start () {
        enemiesNumber = 0;

        eventSystem = GameObject.Instantiate(eventSystem, Vector3.zero, Quaternion.identity) as GameObject;

        canvasGUI = GameObject.Instantiate(canvasGUI, Vector3.zero, Quaternion.identity) as GameObject;

        baseTerrain = GameObject.Instantiate(baseTerrain, Vector3.zero, Quaternion.identity) as GameObject;

        FPC = GameObject.Instantiate(FPC, bornPosition, Quaternion.identity) as GameObject;

        StartCoroutine(CheckGameCoroutine());
	}

    IEnumerator CheckGameCoroutine()
    {
        while (state == 0)
        {
            if (!GameStatement.gameStatement.paused && GameStatement.canCheckGame && GameStatement.levelStatementIsDone)
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
            yield return 0;
        }
    }

    public virtual int checkGame()
    {
        return 0;
    }

    public virtual void passLevel()
    {
        Message.RaiseOneMessage<string>("PassLevel", this, "");
    }

    public virtual void loseLevel()
    {
        Message.RaiseOneMessage<string>("LoseLevel", this, "");
    }
}
