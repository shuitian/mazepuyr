using UnityEngine;
using System.Collections;

public class CreateOneEnemy : MonoBehaviour {

    //GameObject obj; 
    //public int RandX;
    //public int RandZ;
    //// Use this for initialization
    //void Start () {
    //    obj = Resources.Load("prefab/SphereEnemy") as GameObject;
    //    obj.name = "SphereEnemy" + 1;
    //}
	
    //// Update is called once per frame
    //void Update () {
	
    //}

    //void GenerateRandomLocation () {
    //    RandX = Random.Range(LevelStatement.terrainMinX + 1, LevelStatement.terrainMaxX - 1);
    //    RandZ = Random.Range(LevelStatement.terrainMinZ + 1, LevelStatement.terrainMaxZ - 1);
    //}

    //public void addOneEnemy(Vector3 postion, GameObject obj, EnemyStatement enemyStatement)
    //{
    //    obj.transform.position = postion;
    //    EnemyStatement statement = obj.GetComponent<EnemyStatement>();
    //    statement.setEnemyStatement(enemyStatement);
    //    this.obj = obj;
    //    GameStatement.gameStatement.enemiesNumber++;
    //    GameStatement.gameStatement.enemiesAlive++;
    //}

    //public void addOneEnemy(Vector3 postion, GameObject obj)
    //{
    //    obj.transform.position = postion;
    //    this.obj = obj;
    //    GameStatement.gameStatement.enemiesNumber++;
    //    GameStatement.gameStatement.enemiesAlive++;
    //}

    //public void addOneEnemy(GameObject obj)
    //{
    //    GenerateRandomLocation();
    //    obj.transform.position = new Vector3(RandX, 100, RandZ);
    //    this.obj = obj;
    //    GameStatement.gameStatement.enemiesNumber++;
    //    GameStatement.gameStatement.enemiesAlive++;
    //}

    //public void addOneSphereEnemy(Vector3 postion)
    //{
    //    GenerateRandomLocation();
    //    //创建Sphere对象   
    //    obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //    //移动至指定坐标
    //    obj.transform.position = postion;
    //    obj.AddComponent("Rigidbody");
    //    //对象名称   
    //    obj.name = "Andy";  
    //    //材质渲染，(Texture)强制转换  
    //    obj.renderer.material.mainTexture = (Texture)Resources.Load("0");
    //    obj.AddComponent("EnemyAI");
    //    obj.AddComponent("EnemyStatement");
    //    GameStatement.gameStatement.enemiesNumber++;
    //    GameStatement.gameStatement.enemiesAlive++;
    //}

    //public void addOneSphereEnemy()
    //{
    //    GenerateRandomLocation();
    //    //创建Sphere对象   
    //    obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //    //移动至指定坐标
    //    obj.transform.position = new Vector3(RandX, 100, RandZ);
    //    obj.AddComponent("Rigidbody");
    //    //对象名称   
    //    obj.name = "Andy";
    //    //材质渲染，(Texture)强制转换  
    //    obj.renderer.material.mainTexture = (Texture)Resources.Load("0");
    //    obj.AddComponent("EnemyAI");
    //    obj.AddComponent("EnemyStatement");
    //    GameStatement.gameStatement.enemiesNumber++;
    //    GameStatement.gameStatement.enemiesAlive++;
    //}

    //public GameObject getObj()
    //{
    //    return obj;
    //}
}
