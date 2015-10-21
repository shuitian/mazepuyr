using UnityEngine;
using System.Collections;
using System.Threading;
using Regame;

public class GameStatement : MonoBehaviour {
    
    static public GameStatement gameStatement;

    public Transform enemyPoolTransform;
    public Transform bulletPoolTransform;
    
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
        gameStatement = this;
        Message.RegeditMessageHandle<string>("Pause", OnPause);
        Message.RegeditMessageHandle<string>("Resume", OnResume);
        Message.RegeditMessageHandle<string>("Return", OnReturn);
        Message.RegeditMessageHandle<string>("Replay", OnReplay);
        Message.RegeditMessageHandle<string>("NextLevel", OnNextLevel);
        DontDestroyOnLoad(gameObject);
    }

    void OnDestroy()
    {
        Message.UnregeditMessageHandle<string>("Pause", OnPause);
        Message.UnregeditMessageHandle<string>("Resume", OnResume);
        Message.UnregeditMessageHandle<string>("Return", OnReturn);
        Message.UnregeditMessageHandle<string>("Replay", OnReplay);
        Message.UnregeditMessageHandle<string>("NextLevel", OnNextLevel);
    }

    void OnPause(string messageName, object sender, string empty)
    {
        Regame.Time.Pause();
        Cursor.visible = true;
    }

    void OnResume(string messageName, object sender, string empty)
    {
        Regame.Time.Resume();
        Cursor.visible = false;
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
        Refresh();
    }

    void Refresh()
    {
        SkillCure.patients = new ArrayList();
        ObjectPool.Refresh();
    }
}
