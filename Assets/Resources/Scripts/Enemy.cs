using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    float shotTimer = 1;
    bool leftShot = true;
    public float health = 20;
    bool dead = false;


    void Update ()
    {
        if (!dead)
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
                dead = true;
                GetComponent<Animator>().SetTrigger("Explosion");
                GetComponent<PolygonCollider2D>().enabled = false;
            }

        }
        else
        {
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Dead"))
            {
                Destroy(gameObject);
            }
        }

    }

}
