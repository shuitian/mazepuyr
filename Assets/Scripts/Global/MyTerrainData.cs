using UnityEngine;
using System.Collections;

public class MyTerrainData : MonoBehaviour {

    public static MyTerrainData myTerrainData;
    public static TerrainData terrainData;
	// Use this for initialization
	void Awake () {
        myTerrainData = this;
        terrainData = GetComponent<Terrain>().terrainData;
	}
}
