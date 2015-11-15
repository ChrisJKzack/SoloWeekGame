using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    float shotTimer = 1;
    bool leftShot = true;
    public float health = 20;

	void Update ()
    {
        if (shotTimer <= 0)
        {
            if (leftShot)
            {
                Instantiate(Resources.Load("Prefab/Enemy/Laser/1"), transform.position + new Vector3(-.25f, -.3f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(Resources.Load("Prefab/Enemy/Laser/1"), transform.position + new Vector3(.25f, -.3f, 0), Quaternion.identity);
            }

            leftShot = !leftShot;
            shotTimer = 1;
        }

        shotTimer -= Time.deltaTime;

        if (health <= 0)
        {
            Death();
        }
	
	}

    void Death()
    {
        Destroy(gameObject);
    }


}
