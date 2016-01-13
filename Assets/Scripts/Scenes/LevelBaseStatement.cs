using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityTool.Libgame;
public class LevelBaseStatement : MonoBehaviour {

    public int terrainMinX = 0;
    public int terrainMaxX = 2000;
    public int terrainMinY = 0;
    public int terrainMaxY = 2000;
    public int terrainMinZ = 0;
    public int terrainMaxZ = 2000;

    public int enemiesAlive = 0;
    protected int enemiesNumber;
    public int maxEnemiesNumber = 0;
    public static  LevelBaseStatement levelBaseStatement;
    static public bool levelStatementIsDone;
    static public bool canCheckGame;

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
        Log.WriteLog("场景初始化\t\t" + this);
        if (!GameObject.FindGameObjectWithTag("GameController"))
        {
            Object prefab = Resources.Load("Prefabs/GameSystem");
            if (prefab)
            {
                GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            }
        }
        Message.RegeditMessageHandle<int>("AddEnemyAlive", addEnemyAlive);
        Message.RegeditMessageHandle<int>("SubEnemyAlive", subEnemyAlive);
        levelBaseStatement = this;
    }

    void OnDestroy()
    {
        Message.UnregeditMessageHandle<int>("AddEnemyAlive", addEnemyAlive);
        Message.UnregeditMessageHandle<int>("SubEnemyAlive", subEnemyAlive);
    }

	// Use this for initialization
	protected void Start () {
        levelStatementIsDone = false;
        canCheckGame = false;

        enemiesNumber = 0;

        eventSystem = GameObject.Instantiate(eventSystem, Vector3.zero, Quaternion.identity) as GameObject;

        canvasGUI = GameObject.Instantiate(canvasGUI, Vector3.zero, Quaternion.identity) as GameObject;

        baseTerrain = GameObject.Instantiate(baseTerrain, Vector3.zero, Quaternion.identity) as GameObject;

        FPC = GameObject.Instantiate(FPC, bornPosition, Quaternion.identity) as GameObject;

        StartCoroutine(CheckGameCoroutine());

        Log.WriteLog("成功载入场景\t\t" + this);
    }

    IEnumerator CheckGameCoroutine()
    {
        while (state == 0)
        {
            if (!UnityTool.Libgame.Time.isPaused && canCheckGame && levelStatementIsDone)
            {
                state = checkGame();
                if (state == 1)
                {
                    Log.WriteLog("挑战成功");
                    passLevel();
                }
                else if (state == -1)
                {
                    Log.WriteLog("挑战失败");
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

    protected void addEnemyAlive(string messageName, object sender, int number = 1)
    {
        enemiesAlive += number;
        Message.RaiseOneMessage<int>("UpdateEnemiesNumber", this, enemiesAlive);
    }

    protected void subEnemyAlive(string messageName, object sender, int number = 1)
    {
        enemiesAlive -= number;
        Message.RaiseOneMessage<int>("UpdateEnemiesNumber", this, enemiesAlive);
    }

    public int getEnemiesAlive()
    {
        return enemiesAlive;
    }
}
