using UnityEngine;
using System.Collections;
using System.Threading;
using Regame;

public class GameStatement : MonoBehaviour {
    
    static public bool levelStatementIsDone;
    static public LevelBaseStatement levelStatement;
    
    static public GameStatement gameStatement;
    static public float savedTimeScale;
    public bool paused = false;

    public Transform enemyPoolTransform;
    public Transform bulletPoolTransform;

    protected int enemiesAlive = 0;
    public bool playerIsAllAlive = true;
    public int playerNumber = 1;
    public int gameLevel = 0;
    public int maxGameLevel = 1;
    static public bool canCheckGame;
    static public string helpInfo = "\n  帮助信息\n  ESC:暂停\n  W:前进\tA:左移\n  S:后退\tD:右移\n  空格:跳跃\t鼠标左键:攻击\n\n  作者:puyr\n  E-mail:mazepuyr@163.com\n  版本:1.07\n";
    static public string[] LevelTitle = { 
            "", 
            "荒芜平原 前章", 
            "荒芜平原 中章", 
            "荒芜平原 后章", 
            "尖牙山岭", 
            "矛石领地", 
            "交错之境 前章", 
            "交错之境 中章", 
            "交错之境 后章" 
    };
    
    void Awake()
    {
        Message.RegeditMessageHandle<int>("AddEnemyAlive", addEnemyAlive);
        Message.RegeditMessageHandle<int>("SubEnemyAlive", subEnemyAlive);
        Message.RegeditMessageHandle<string>("Pause", OnPause);
        Message.RegeditMessageHandle<string>("Resume", OnResume);
        Message.RegeditMessageHandle<string>("Return", OnReturn);
        Message.RegeditMessageHandle<string>("Replay", OnReplay);
        Message.RegeditMessageHandle<string>("NextLevel", OnNextLevel);
        DontDestroyOnLoad(gameObject);
    }

    void OnDestroy()
    {
        Message.UnregeditMessageHandle<int>("AddEnemyAlive", addEnemyAlive);
        Message.UnregeditMessageHandle<int>("SubEnemyAlive", subEnemyAlive);
        Message.UnregeditMessageHandle<string>("Pause", OnPause);
        Message.UnregeditMessageHandle<string>("Resume", OnResume);
        Message.UnregeditMessageHandle<string>("Return", OnReturn);
        Message.UnregeditMessageHandle<string>("Replay", OnReplay);
        Message.UnregeditMessageHandle<string>("NextLevel", OnNextLevel);
    }

	// Use this for initialization
	void Start () {
        gameStatement = this;
        levelStatementIsDone = false;
        canCheckGame = false;
	}
	
    void addEnemyAlive(string messageName, object sender, int number = 1)
    {
        enemiesAlive += number;
        Message.RaiseOneMessage<int>("UpdateEnemiesNumber", this, enemiesAlive);
    }

    void subEnemyAlive(string messageName, object sender, int number = 1)
    {
        enemiesAlive -= number;
        Message.RaiseOneMessage<int>("UpdateEnemiesNumber", this, enemiesAlive);
    }

    void OnPause(string messageName, object sender, string empty)
    {
        GameStatement.savedTimeScale = Time.timeScale;
        Time.timeScale = 0;
        Cursor.visible = true;
        GameStatement.gameStatement.paused = true;
    }

    void OnResume(string messageName, object sender, string empty)
    {
        Time.timeScale = GameStatement.savedTimeScale;
        Cursor.visible = false;
        GameStatement.gameStatement.paused = false;
    }

    void OnReturn(string messageName, object sender, string empty)
    {
        Cursor.visible = true;
        Application.LoadLevel("start");
    }

    void OnReplay(string messageName, object sender, string empty)
    {
        Application.LoadLevel(Application.loadedLevel); 
    }

    void OnNextLevel(string messageName, object sender, string empty)
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    void OnLevelWasLoaded(int l)
    {
        gameLevel = l - 1;
        levelStatement = LevelBaseStatement.levelBaseStatement;
        Refresh();
    }

    public void Refresh()
    {
        GameStatement.levelStatementIsDone = false;
        enemiesAlive = 0;
        canCheckGame = false;
        SkillCure.patients = new ArrayList();
        ObjectPool.Refresh();
    }

    public int getEnemiesAlive()
    {
        return enemiesAlive;
    }
}
