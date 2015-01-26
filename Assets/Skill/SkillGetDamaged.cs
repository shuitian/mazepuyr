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
            if (getDamagedStatement != null && bulletBaseParameter != null && bulletBaseParameter.damager!=null  && !isFriend(bulletBaseParameter.damager.tag, getDamagedStatement.tag)) 
            {
                getDamagedStatement.loseHp(bulletBaseParameter.damager, bulletBaseParameter.getDamage());
            }
        }
    }

    bool isFriend(string tag1, string tag2)
    {
        if (((tag1.IndexOf(tag2) <= -1) && (tag2.IndexOf(tag1) <= -1)) && ((tag2.IndexOf("Enemy") > -1) || tag2.IndexOf("Player") > -1))
        {
            return false;
        }
        return true;
    }
}
