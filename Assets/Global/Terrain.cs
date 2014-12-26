using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour {

    public static GameObject terrain;
	// Use this for initialization
	void Start () {
        terrain = GameObject.FindGameObjectWithTag("Terrain");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
