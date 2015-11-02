using UnityEngine;
using System.Collections;
using UnityTool.Libgame;

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
    public GameObject explodePrefab;

    void OnEnable()
    {
        enableTime = UnityEngine.Time.time;
        enableTransform = transform;
        GetComponent<Rigidbody>().velocity = enableTransform.forward * speed;
    }

	// Update is called once per frame
	void Update () {
        if (LevelBaseStatement.levelStatementIsDone)
        {
            if (transform.position.y < LevelBaseStatement.levelBaseStatement.terrainMinY
                || transform.position.x < LevelBaseStatement.levelBaseStatement.terrainMinX
                    || transform.position.z < LevelBaseStatement.levelBaseStatement.terrainMinZ
                        || transform.position.x > LevelBaseStatement.levelBaseStatement.terrainMaxX
                            || transform.position.y > LevelBaseStatement.levelBaseStatement.terrainMaxY
                                || transform.position.z > LevelBaseStatement.levelBaseStatement.terrainMaxZ
                                    || UnityEngine.Time.time > enableTime + lifeTime)
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
        if (explodePrefab)
        {
            Instantiate(explodePrefab, transform.position, transform.rotation);
        }
        ObjectPool.Destroy(gameObject);
    }
}
