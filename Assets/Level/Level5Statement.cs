using UnityEngine;
using System.Collections;

public class Level5Statement : LevelBaseStatement
{
    public GameObject enemyYellowSphere;

    bool flag;
    Vector3 p1, p2, p3, p4;
    int step;
    int origin;
    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
        levelTitle = "矛石领地";
        levelIntroduction = "\n\t白色军团被彻底打败，只余下一小部分逃回去，你在追击过程中，陷入了七彩军团的矛石部队。矛石部队身披黄袍，手中的黄色长矛是他们远距离打击的利器\n\t作为红龙殿的传人，你做好了向敌人展示力量的准备了吗？\n\t胜利条件:剩余敌人数为0\n\t失败条件:生命值小于等于0\n";
        info = "\t矛石领地\n\n\t胜利条件:剩余敌人数为0\n\t失败条件:生命值小于等于0";
    }

    // Use this for initialization
    void Start()
    {
        base.Start();

        flag = false;
        origin = 600;
        step = 35;
        p1 = new Vector3(origin, 50, origin);
        p2 = new Vector3(2000 - origin, 50, origin);
        p3 = new Vector3(2000 - origin, 50, 2000 - origin);
        p4 = new Vector3(origin, 50, 2000 - origin);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (!flag && GameStatement.levelStatementIsDone)
        {
            if (p1.x >= 2000 - origin)
            {
                flag = true;
                return;
            }
            else
            {
                GameObject clone;
                clone = EnemyPool.Enemy(enemyYellowSphere, p1, Quaternion.identity) as GameObject;
                p1 += new Vector3(step, 0, 0);

                clone = EnemyPool.Enemy(enemyYellowSphere, p2, Quaternion.identity) as GameObject;
                p2 += new Vector3(0, 0, step);

                clone = EnemyPool.Enemy(enemyYellowSphere, p3, Quaternion.identity) as GameObject;
                p3 -= new Vector3(step, 0, 0);

                clone = EnemyPool.Enemy(enemyYellowSphere, p4, Quaternion.identity) as GameObject;
                p4 -= new Vector3(0, 0, step);

                GameStatement.beginGenereate = true;
            }
        }
    }

    public override int checkGame()
    {
        if (GameStatement.gameStatement.getEnemiesAlive() <= 0)
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
