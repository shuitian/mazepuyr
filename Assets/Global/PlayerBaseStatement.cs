using UnityEngine;
using System.Collections;

public class PlayerBaseStatement : MonoBehaviour {

    public float hp;
    public float maxHp;
    public float mp;
    public float maxMp;
    public float exp;
    public int lifeRemain;
    public int maxLife;
    public int level;
    public int maxLevel;
    static public float[] maxExpPerLevel = { 100F, 100F, 100F, 100F, 100F, 100F, 100F, 100F, 100F, 100F };
    static public float[] baseAttackPerLevel = { 1F, 2F, 3F, 4F, 5F, 6F, 7F, 8F, 9F, 10F };
    static public float[] baseDefensePerLevel = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F };

    public Vector3 bornPosition;
    static public PlayerBaseStatement playerBaseStatement;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool isAlive()
    {
        if (lifeRemain <= 0)
        {
            return false;
        }
        if (!isPositionRight())
        {
            return false;
        }
        return true;
    }



    public bool isPositionRight()
    {
        if (GameStatement.levelStatementIsDone)
        {
            if (transform.position.y <= GameStatement.levelStatement.terrainMinY
                   || transform.position.x <= GameStatement.levelStatement.terrainMinX
                       || transform.position.z <= GameStatement.levelStatement.terrainMinZ
                           || transform.position.x >= GameStatement.levelStatement.terrainMaxX
                               || transform.position.y >= GameStatement.levelStatement.terrainMaxY
                                   || transform.position.z >= GameStatement.levelStatement.terrainMaxZ)
            {
                return false;
            }
        }
        return true;
    }

    public virtual void loseHp(float losedHp)
    {
    }

    public virtual void getExp(float exp)
    {
    }

    public virtual void loseLevel()
    {
    }

    public virtual void passLevel()
    {
    }

    public virtual void Refresh()
    {
    }
}
