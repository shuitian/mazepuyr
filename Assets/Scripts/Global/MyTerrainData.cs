using UnityEngine;
using System.Collections;

public class MyTerrainData : MonoBehaviour {

    public static TerrainData terrainData;
	// Use this for initialization
	void Start () {
        terrainData = GetComponent<Terrain>().terrainData;
	}
	
	// Update is called once per frame
	void Update () {
        //print(terrainData);
	}
}
