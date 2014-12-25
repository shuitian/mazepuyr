using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpShow : MonoBehaviour
{

	// Use this for initialization
	void Start () {
   
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void updateGUI(float hp, float maxHp)
    {
        gameObject.GetComponent<Text>().text = hp + "/" + maxHp;
    }
}
