using UnityEngine;
using System.Collections;

public class SkillPlayerMoveInSpace : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update () {
        float x= Input.GetAxis("Vertical");
        float y= -Input.GetAxis("Horizontal");
        Vector3 v = (transform.forward * y + transform.right * x).normalized * speed;
        transform.position = transform.position + v * Time.deltaTime;
        if (transform.position.x >= 2000)
        {
            transform.position = new Vector3(2000, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= 0) 
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        if (transform.position.y >= 2000)
        {
            transform.position = new Vector3(transform.position.x, 2000, transform.position.z);
        }
        if (transform.position.y <= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        if (transform.position.z >= 2000)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 2000);
        }
        if (transform.position.z <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
