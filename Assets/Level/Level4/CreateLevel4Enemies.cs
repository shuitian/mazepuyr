using UnityEngine;
using System.Collections;

public class CreateLevel4Enemies : CreateLevelEnemies
{
    static public GameObject bigSphere;
    public BigSphereStatement bigSphereStatement;
    bool flag = false;
    // Use this for initialization
    void Start()
    {
        bigSphereStatement = GetComponent<BigSphereStatement>();

        if (!flag && GameStatement.levelStatementIsDone)
        {
            bigSphere = Instantiate(bigSphereStatement.getObj(), new Vector3(1000, 0, 400), Quaternion.identity) as GameObject;
            flag = true;
            bigSphere.GetComponentInChildren<BigSphereAI>().setCreatedObject("Prefab/Enemy/FlyingSphere");
            bigSphere.name = "BigSphere";
            bigSphere.transform.parent = gameObject.transform;
            enemiesNumber++;
            GameStatement.gameStatement.enemiesAlive++;
            GameStatement.beginGenereate = true;
            EnemiesNumberShow.enemiesNumberShow.updateGUI(GameStatement.gameStatement.enemiesAlive);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Refresh()
    {
        base.Refresh();
        flag = false;
        Start();
    }
}
