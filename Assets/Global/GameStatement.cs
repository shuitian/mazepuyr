using UnityEngine;
using System.Collections;
using System.Threading;

public class GameStatement : MonoBehaviour {

    static public bool levelStatementIsDone;
    static public LevelBaseStatement levelStatement;
    static public GameStatement gameStatement;
    static public float savedTimeScale;
    public bool paused = false;
    //public int enemiesNumber = 0;
    //public int enemiesMaxNumber = 100;
    public int enemiesAlive = 0;
    public bool playerIsAllAlive = true;
    public int playerNumber = 1;
    public int gameLevel = 0;
    public int maxGameLevel = 1;
    static public bool beginGenereate;
    static public string helpInfo = "\n  帮助信息\n  ESC:暂停\n  W:前进\tA:左移\n  S:后退\tD:右移\n  空格:跳跃\t鼠标左键:攻击\n\n  作者:puyr\n  E-mail:mazepuyr@163.com\n  版本:1.05\n";
    static public string[] LevelTitle ={"", "荒芜平原 前章", "荒芜平原 中章", "荒芜平原 后章", "尖牙山岭", "矛石领地" , "交错之境" };

    public Mutex m = new Mutex();
    public static GameObject bulletGroup;

    static public int Difficult;
	// Use this for initialization
	void Start () {
        gameStatement = GetComponent<GameStatement>();
        levelStatementIsDone = false;
        beginGenereate = false;
        bulletGroup = GameObject.FindGameObjectWithTag("BulletGroup");
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

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void OnLevelWasLoaded(int l)
    {
        int level = l - 1;
        gameLevel = level;
        enemiesAlive = 0;
        //print(level);
        switch (level)
        {
            case 1:
                OnLevelWasLoaded(0);
                var component = gameObject.AddComponent("Level1Statement");
                levelStatement = component.gameObject.GetComponent<Level1Statement>();
                //savedTimeScale = Time.timeScale;
                //Time.timeScale = 0;
                //levelStatementIsDone = true;
                break;
            case 2:
                OnLevelWasLoaded(0);
                component = gameObject.AddComponent("Level2Statement");
                levelStatement = component.gameObject.GetComponent<Level2Statement>();
                //savedTimeScale = Time.timeScale;
                //Time.timeScale = 0;
                //levelStatementIsDone = true;
                break;
            case 3:
                OnLevelWasLoaded(0);
                component = gameObject.AddComponent("Level3Statement");
                levelStatement = component.gameObject.GetComponent<Level3Statement>();
                //savedTimeScale = Time.timeScale;
                //Time.timeScale = 0;
                //levelStatementIsDone = true;
                break;
            case 4:
                OnLevelWasLoaded(0);
                component = gameObject.AddComponent("Level4Statement");
                levelStatement = component.gameObject.GetComponent<Level4Statement>();
                //savedTimeScale = Time.timeScale;
                //Time.timeScale = 0;
                //levelStatementIsDone = true;
                break;
            case 5:
                OnLevelWasLoaded(0);
                component = gameObject.AddComponent("Level5Statement");
                levelStatement = component.gameObject.GetComponent<Level5Statement>();
                //savedTimeScale = Time.timeScale;
                //Time.timeScale = 0;
                //levelStatementIsDone = true;
                break;
            case 6:
                OnLevelWasLoaded(0);
                component = gameObject.AddComponent("Level6Statement");
                levelStatement = component.gameObject.GetComponent<Level6Statement>();
                //savedTimeScale = Time.timeScale;
                //Time.timeScale = 0;
                //levelStatementIsDone = true;
                break;
            default:
                var statements = gameObject.GetComponents<LevelBaseStatement>();
                foreach (LevelBaseStatement statement in statements)
                {
                    Destroy(statement);
                }
                break;
        }
    }

    public void Refresh()
    {
        enemiesAlive = 0;
        beginGenereate = false;
    }

    public void setLevelStatementDone()
    {
        levelStatementIsDone = true;
    }
}
