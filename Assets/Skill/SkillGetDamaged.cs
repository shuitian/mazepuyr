using UnityEngine;
using System.Collections;

public class SkillGetDamaged : MonoBehaviour
{
    public BaseStatement getDamagedStatement;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.isTrigger)
        {
            return;
        }
        if (collider.gameObject.tag == "Bullet")
        {
            BulletBaseParameter bulletBaseParameter = collider.gameObject.GetComponent<BulletBaseParameter>();
            if (getDamagedStatement != null && bulletBaseParameter.damager.tag != getDamagedStatement.tag) 
            {
                //print(bulletBaseParameter.damager.tag + " VS " + getDamagedStatement.tag);
                getDamagedStatement.loseHp(bulletBaseParameter.damager, bulletBaseParameter.getDamage());
            }
        }
    }
}
