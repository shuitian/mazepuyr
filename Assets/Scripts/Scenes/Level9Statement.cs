using UnityEngine;
using UnityTool.Libgame;

public class Level9Statement : LevelBaseStatement
{
    public GameObject enemyPurpleSphere;
    bool flag;
    // Use this for initialization
    protected new void Awake()
    {
        base.Awake();
        levelTitle = "荒芜平原 空中拦截";
        levelIntroduction = "\n\t你驾驶飞行器逃脱了敌人的围攻，回到荒芜平原的时候，却发现荒芜平原已经成为了紫色军团的空中战场，紫色军团人手一捆追踪箭\n\t作为红龙殿的传人，你做好了向敌人展示力量的准备了吗？\n\t胜利条件:剩余敌人数为0\n\t失败条件:生命值小于等于0\n";
        info = "\t空中防御\n\n\t胜利条件:剩余敌人数为0\n\t失败条件:生命值小于等于0";
    }

    // Use this for initialization
    new void Start()
    {
        base.Start();
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!flag && levelStatementIsDone)
        {
            if (enemiesNumber >= maxEnemiesNumber)
            {
                flag = true;
                return;
            }
            int x = Random.Range(terrainMinX + 1, terrainMaxX - 1);
            int y = Random.Range(terrainMinY + 1, terrainMaxY - 1);
            int z = Random.Range(terrainMinZ + 1, terrainMaxZ - 1);
            ObjectPool.Instantiate(enemyPurpleSphere, new Vector3(x, y, z), Quaternion.identity, GameStatement.gameStatement.enemyPoolTransform);
            Message.RaiseOneMessage<int>("AddEnemyAlive", this, 1);
            enemiesNumber++;
            if (!canCheckGame && enemiesNumber > 30)
            {
                canCheckGame = true;
            }
        }
    }

    public override int checkGame()
    {
        if (getEnemiesAlive() <= 0)
        {
            return 1;
        }
        if (PlayerBaseStatement.playerBaseStatement.lifeRemain <= 0)
        {
            return -1;
        }
        return 0;
    }
}
