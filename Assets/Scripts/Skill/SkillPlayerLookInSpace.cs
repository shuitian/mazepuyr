using UnityEngine;
using System.Collections;

public class SkillPlayerLookInSpace : MonoBehaviour {

    public float sensitivityX = 3F;
    public float sensitivityY = 2F;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0)
        {
            return;
        }
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        transform.Rotate(0, x * sensitivityX, y * sensitivityY);

    }
}
