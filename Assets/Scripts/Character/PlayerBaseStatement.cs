using UnityEngine;
using System.Collections;
using Regame;

public class PlayerBaseStatement : BaseStatement {

    static public PlayerBaseStatement playerBaseStatement;
    static public GameObject player;
	// Use this for initialization
	protected void Awake () {
        base.Awake();
        playerBaseStatement = this;
        player = gameObject;

        Message.RegeditMessageHandle<string>("LevelIsDone", showInitStatement);
	}

    void OnDestroy()
    {
        Message.UnregeditMessageHandle<string>("LevelIsDone", showInitStatement);
    }

    void showInitStatement(string messageName, object sender, string empty)
    {
        Message.RaiseOneMessage<int>("UpdatePlayerLevelText", this, level);
        Message.RaiseOneMessage<float[]>("UpdatePlayerHpText", this, new float[] { hp, maxHp[level] });
        Message.RaiseOneMessage<float[]>("UpdatePlayerMpText", this, new float[] { mp, maxMp[level] });
        Message.RaiseOneMessage<float[]>("UpdatePlayerExpText", this, new float[] { exp, maxExpPerLevel[level] });
        transform.position = LevelBaseStatement.levelBaseStatement.bornPosition;
    }

    public override bool die(BaseStatement killer)
    {
        if (base.die(killer) == true)
        {
            return true;
        }
        return false;
    }

    public override void loseHp(BaseStatement damager, float losedHp)
    {
        base.loseHp(damager, losedHp);
        Message.RaiseOneMessage<float[]>("UpdatePlayerHpText", this, new float[] { hp, maxHp[level] });
    }

    public override bool loseMp(float losedMp)
    {
        if (base.loseMp(losedMp))
        {
            Message.RaiseOneMessage<float[]>("UpdatePlayerMpText", this, new float[] { mp, maxMp[level] });
            return true;
        }
        return false;
    }

    public override float recoverHp(float recover)
    {
        float ret = base.recoverHp(recover);
        if (ret != 0)
        {
            Message.RaiseOneMessage<float[]>("UpdatePlayerHpText", this, new float[] { hp, maxHp[level] });
        }
        return ret;
    }

    public override float recoverMp(float recover)
    {
        float ret = base.recoverMp(recover);
        if (ret != 0)
        {
            Message.RaiseOneMessage<float[]>("UpdatePlayerMpText", this, new float[] { mp, maxMp[level] });
        }
        return ret;
    }

    public override void getExp(BaseStatement expFrom, float e)
    {
        base.getExp(expFrom, e);
        Message.RaiseOneMessage<float[]>("UpdatePlayerExpText", this, new float[] { exp, maxExpPerLevel[level] });
    }

    public override void growLevel(int l)
    {
        base.growLevel(l);
        Message.RaiseOneMessage<int>("UpdatePlayerLevelText", this, level);
        Message.RaiseOneMessage<float[]>("UpdatePlayerHpText", this, new float[] { hp, maxHp[level] });
        Message.RaiseOneMessage<float[]>("UpdatePlayerMpText", this, new float[] { mp, maxMp[level] });
        Message.RaiseOneMessage<float[]>("UpdatePlayerExpText", this, new float[] { exp, maxExpPerLevel[level] });
    }
}
