using UnityEngine;
using System.Collections;

public class GameStatement : MonoBehaviour {

    static public GameStatement gameStatement;
    static public float savedTimeScale;
    public bool paused = false;
    public int enemiesNumber = 0;
    public int enemiesMaxNumber = 100;
    public int enemiesAlive = 0;
    public bool playerIsAllAlive = true;
    public int playerNumber = 1;
    public int gameLevel = 0;
    public int maxGameLevel = 1;
    public bool retFlag = false;
    //static private bool reload = false;
	// Use this for initialization
	void Start () {
        gameStatement = GetComponent<GameStatement>();
	}
	
	// Update is called once per frame
	void Update () {
        //if (reload == false)
        //{
        //    Destroy(gameObject);
        //    reload = true;
        //    Application.LoadLevel(1);
        //    Application.LoadLevel(0);
        //}
	}

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        //Application.LoadLevel(0);
    }

    //void OnLevelWasLoaded(int level)
    //{ 
    //    enemiesNumber = 0;
    //    enemiesMaxNumber = 100;
    //    enemiesAlive = 0;
    //    playerIsAllAlive = true;
    //    gameLevel = level;
    //}
}
