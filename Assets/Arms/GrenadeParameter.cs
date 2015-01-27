using UnityEngine;
using System.Collections;

public class GrenadeParameter : MonoBehaviour {

    public float speed = 0;
    public float damage = 10;
    public BaseStatement damager;

    public float explodeRadius = 10;
    public float lifeTime = 4F;
    private float enableTime = 0F;
    private Transform enableTransform;
    private float dist;

    public float costMp = 5;
	// Use this for initialization
	void Start () {
	
	}

    void OnEnable()
    {
        enableTime = Time.time;
        enableTransform = transform;
        rigidbody.velocity = enableTransform.forward * speed;
    }

	// Update is called once per frame
	void Update () {
        if (GameStatement.levelStatementIsDone)
        {
            if (transform.position.y < GameStatement.levelStatement.terrainMinY
                || transform.position.x < GameStatement.levelStatement.terrainMinX
                    || transform.position.z < GameStatement.levelStatement.terrainMinZ
                        || transform.position.x > GameStatement.levelStatement.terrainMaxX
                            || transform.position.y > GameStatement.levelStatement.terrainMaxY
                                || transform.position.z > GameStatement.levelStatement.terrainMaxZ
                                    || Time.time > enableTime + lifeTime)
            {
                explode();
            }
        }
	}

    void explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explodeRadius);
        foreach (Collider collider in colliders)
        {
            SkillGetDamaged skillGetDamaged = collider.GetComponent<SkillGetDamaged>();
            if (skillGetDamaged == null || skillGetDamaged.getDamagedStatement == null)
            {
                continue;
            }
            skillGetDamaged.getDamagedStatement.loseHp(damager, damage * (1 - skillGetDamaged.getDamagedStatement.baseDefensePerLevel[skillGetDamaged.getDamagedStatement.level]));
        }
        BulletPool.Destroy(gameObject);
    }
}
