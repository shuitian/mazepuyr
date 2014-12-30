using UnityEngine;
using System.Collections;

public class BaseCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected void Update () {
        if (GameStatement.levelStatementIsDone)
        {
            try
            {
                if (transform.position.y <= GameStatement.levelStatement.terrainMinY
                        || transform.position.x <= GameStatement.levelStatement.terrainMinX
                            || transform.position.z <= GameStatement.levelStatement.terrainMinZ
                                || transform.position.x >= GameStatement.levelStatement.terrainMaxX
                                    || transform.position.y >= GameStatement.levelStatement.terrainMaxY
                                        || transform.position.z >= GameStatement.levelStatement.terrainMaxZ)
                {
                    Destroy(gameObject);
                }
            }
            finally
            {
            }
        }
	}

    protected void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.isStatic)
        {
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
