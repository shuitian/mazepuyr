using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatement : MonoBehaviour {

    public float hp;
    public float maxHp = 100F;
    public float mp;
    public float maxMp = 100F;
    public float exp = 0;
    public int lifeRemain;
    public int maxLife = 1;
    public int level;
    public int maxLevel = 10;
    static public float[] maxExpPerLevel = { 100F, 100F, 100F, 100F, 100F, 100F, 100F, 100F, 100F, 100F };
    static public float[] baseAttackPerLevel = { 1F, 2F, 3F, 4F, 5F, 6F, 7F, 8F, 9F, 10F };
    static public float[] baseDefensePerLevel = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F };
    private HpShow hpShow;

    static public PlayerStatement playerStatement;
	// Use this for initialization
	void Start () {
        maxHp = 100F;
        hp = maxHp;
        maxMp = 100F;
        mp = maxMp;
        level = 1;
        hpShow = GameObject.Find("hpText").GetComponent<HpShow>();
        hpShow.updateGUI(hp, maxHp);
        lifeRemain = maxLife;
        playerStatement = GetComponent<PlayerStatement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameStatement.gameStatement.paused)
        {
            if (!isAlive())
            {
                loseLevel();
            }
        }
	}

    public bool isAlive()
    {
        if (lifeRemain <= 0)
        {
            return false;
        }
        switch (GameStatement.gameStatement.gameLevel)
        {
            case 0:
                break;
            case 1:
                if (transform.position.y <= Level1Statement.terrainMinY || transform.position.x <= Level1Statement.terrainMinX || transform.position.z <= Level1Statement.terrainMinZ ||
                        transform.position.x >= Level1Statement.terrainMaxX || transform.position.y >= Level1Statement.terrainMaxY || transform.position.z >= Level1Statement.terrainMaxZ)
                {
                    return false;
                }
                break;
            default:
                break;
        }
        return true;
    }

    public void loseHp(float losedHp)
    {
        hp -= losedHp;
        if (hp <= 0)
        {
            hp = maxHp;
            lifeRemain--;
            if (!isAlive())
            {
                loseLevel();
            }
        }
        hpShow.updateGUI(hp, maxHp);
    }

    public void getExp(float exp)
    {
        this.exp += exp;
        if (exp > maxExpPerLevel[level])
        {
            exp = 0;
            level++;
        }
    }

    public void loseLevel()
    {
        MsgPanel.msgPanel.showLose();
        MenuControl.menuControl.OnPause();
    }

    public void passLevel()
    {
        MsgPanel.msgPanel.showWin();
        MenuControl.menuControl.OnPause();
    }
}
