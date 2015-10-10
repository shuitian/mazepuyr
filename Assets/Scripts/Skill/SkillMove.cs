using UnityEngine;
using System.Collections;

public class SkillMove : MonoBehaviour {

    public GameObject toBeMoved;
    public GameObject moveTo;
    public float minDistance = 10;
    public float maxDistance = 2000;
    public float moveSpeed = 5;

    public float dist;
    public bool canMove = true; 
    public int checkFrames = 10;
    int i;
	// Use this for initialization
	void Start () {
        
	}

    void OnEnable()
    {
        moveTo = PlayerBaseStatement.player;
        i = 0;
    }


	// Update is called once per frame
    protected void Update()
    {
        if (moveTo == null || !canMove) 
        {
            return;
        }
        if (toBeMoved.GetComponent<Rigidbody>().useGravity)
        {
            toBeMoved.transform.position = toBeMoved.transform.position + (moveTo.transform.position - toBeMoved.transform.position).normalized * moveSpeed * Time.deltaTime;
        }
        else
        {
            toBeMoved.GetComponent<Rigidbody>().velocity = (moveTo.transform.position - toBeMoved.transform.position).normalized * moveSpeed;
        }
	}

    protected void FixedUpdate()
    {
        if (i++ > checkFrames)
        {
            dist = Vector3.Distance(toBeMoved.transform.position, moveTo.transform.position);
            if (dist > minDistance && dist < maxDistance)
            {
                canMove = true;
                i = 0;
            }
            else
            {
                canMove = false;
            }
        }
    }

    public void setMoveTo(GameObject moveTo)
    {
        this.moveTo = moveTo;
    }
}
