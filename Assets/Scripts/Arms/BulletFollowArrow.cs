using UnityEngine;
using System.Collections;

public class BulletFollowArrow : BulletBaseParameter
{
    public BaseStatement target;
    public float rotateSpeed;

	// Update is called once per frame
	new protected void Update () {
        base.Update();
        if (target != null)
        {
            Vector3 d = target.transform.position - transform.position;
            transform.forward = Vector3.RotateTowards(transform.forward, d, rotateSpeed, 0);
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
    }
}
