using UnityEngine;
using System.Collections;

public class SkillFaceToPlayer : MonoBehaviour {

    public GameObject objectFaceTo;
    void Awake()
    {
        objectFaceTo = PlayerBaseStatement.player;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        setCanvasTransform(objectFaceTo);
	}

    protected virtual void setCanvasTransform(GameObject objectFaceTo)
    {
        if (objectFaceTo == null)
        {
            return;
        }
        transform.LookAt(objectFaceTo.transform.position, Vector3.up);
    }

    public void setObjectFaceTo(GameObject objectFaceTo)
    {
        this.objectFaceTo = objectFaceTo;
    }
}
