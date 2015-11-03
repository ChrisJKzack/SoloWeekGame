using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    float shotTimer = 1;
    bool leftShot = true;

	void Update ()
    {
        if (shotTimer <= 0)
        {
            if (leftShot)
            {
                Instantiate(Resources.Load("Prefab/Enemy/Laser/1"), transform.position + new Vector3(-.25f, -.25f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(Resources.Load("Prefab/Enemy/Laser/1"), transform.position + new Vector3(.25f, -.25f, 0), Quaternion.identity);
            }

            leftShot = !leftShot;
            shotTimer = 1;
        }

        shotTimer -= Time.deltaTime;
	
	}
}
