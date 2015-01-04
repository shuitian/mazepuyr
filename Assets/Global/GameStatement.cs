using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	void Start () {
        gameStatement = GetComponent<GameStatement>();
        levelStatementIsDone = false;
        beginGenereate = false;
	}
	
	// Update is called once per frame
    void Update()
    {

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
                levelStatementIsDone = true;
                break;
            case 2:
                OnLevelWasLoaded(0);
                component = gameObject.AddComponent("Level2Statement");
                levelStatement = component.gameObject.GetComponent<Level2Statement>();
                levelStatementIsDone = true;
                break;
            case 3:
                OnLevelWasLoaded(0);
                component = gameObject.AddComponent("Level3Statement");
                levelStatement = component.gameObject.GetComponent<Level3Statement>();
                levelStatementIsDone = true;
                break;
            case 4:
                OnLevelWasLoaded(0);
                component = gameObject.AddComponent("Level4Statement");
                levelStatement = component.gameObject.GetComponent<Level4Statement>();
                levelStatementIsDone = true;
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
}
