using UnityEngine;
using System.Collections;
using System.Threading;

public class GameStatement : MonoBehaviour {
    
    static public bool levelStatementIsDone;
    static public LevelBaseStatement levelStatement;
    static public EnemyPool enemyPool;
    static public BulletPool bulletPool;
    static public GameStatement gameStatement;
    static public float savedTimeScale;

    public bool paused = false;

    protected int enemiesAlive = 0;
    public bool playerIsAllAlive = true;
    public int playerNumber = 1;
    public int gameLevel = 0;
    public int maxGameLevel = 1;
    static public bool beginGenereate;
    static public string helpInfo = "\n  帮助信息\n  ESC:暂停\n  W:前进\tA:左移\n  S:后退\tD:右移\n  空格:跳跃\t鼠标左键:攻击\n\n  作者:puyr\n  E-mail:mazepuyr@163.com\n  版本:1.05\n";
    static public string[] LevelTitle ={"", "荒芜平原 前章", "荒芜平原 中章", "荒芜平原 后章", "尖牙山岭", "矛石领地" , "交错之境" };

    public Mutex m = new Mutex();
    
    static public int Difficult;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        bulletPool = GameObject.FindGameObjectWithTag("BulletGroup").GetComponent<BulletPool>();
        enemyPool = GameObject.FindGameObjectWithTag("Generator").GetComponent<EnemyPool>();
    }

	// Use this for initialization
	void Start () {
        gameStatement = this;
        levelStatementIsDone = false;
        beginGenereate = false;
	}
	
	// Update is called once per frame
    void Update()
    {
    }

    public void addEnemyAlive(int number = 1)
    {
        m.WaitOne();
        enemiesAlive += number;
        GUIEnemyNumberShow.enemiesNumberShow.updateGUI(enemiesAlive);
        m.ReleaseMutex();
    }

    public void subEnemyAlive(int number = 1)
    {
        m.WaitOne();
        enemiesAlive -= number;
        GUIEnemyNumberShow.enemiesNumberShow.updateGUI(enemiesAlive);
        m.ReleaseMutex();
    }

    void OnLevelWasLoaded(int l)
    {
        gameLevel = l - 1;
        levelStatement = LevelBaseStatement.levelBaseStatement;
        Refresh();
    }

    public void Refresh()
    {
        enemiesAlive = 0;
        beginGenereate = false;
        bulletPool.Refresh();
        enemyPool.Refresh();
        if (levelStatement)
        {
            levelStatement.Refresh();
        }
    }

    public void setLevelStatementDone()
    {
        levelStatementIsDone = true;
    }

    public int getEnemiesAlive()
    {
        return enemiesAlive;
    }
}
