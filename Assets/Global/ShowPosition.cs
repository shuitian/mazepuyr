using UnityEngine;
using System.Collections;

public class ShowPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //print(transform.position);
        //transform.position += new Vector3(0, -0.1F, 0);
	}

    public Transform getTransform()
    {
        return transform;
    }
}
