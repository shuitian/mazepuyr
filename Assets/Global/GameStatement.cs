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

	// Use this for initialization
	void Start () {
        gameStatement = GetComponent<GameStatement>();
        levelStatementIsDone = false;
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
        print(level);
        switch (level)
        {
            case 1:
                //OnLevelWasLoaded(0 + 1);
                var component = gameObject.AddComponent("Level1Statement");
                levelStatement = component.gameObject.GetComponent<Level1Statement>();
                levelStatementIsDone = true;
                break;
            case 2:
                //var s = gameObject.GetComponent<Level1Statement>();
                //Destroy(s);
                //OnLevelWasLoaded(0 + 1);
                component = gameObject.AddComponent("Level2Statement");
                //print(levelStatement.bornPosition);
                levelStatement = component.gameObject.GetComponent<Level2Statement>();
                //print(levelStatement.bornPosition);
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

    public void Refresh(int level)
    {
        enemiesAlive = 0;
    }
}
