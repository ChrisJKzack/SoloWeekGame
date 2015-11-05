using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    float moveFactor = 2;
    float shotTimer = 0;
    float health = 20;

	// Update is called once per frame
	void FixedUpdate ()
    {
        MovementManager();
        ShotManager();
    }

    void Update()
    {
        if (health <= 0)
        {
            Death();
        }
    }

    void MovementManager()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + Time.deltaTime * moveFactor, transform.position.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - Time.deltaTime * moveFactor, transform.position.y);
        }
    }

    void ShotManager()
    {
        if (shotTimer <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(Resources.Load("Prefab/Player/Laser"),transform.position+new Vector3(0,.5f,0),Quaternion.identity);
                shotTimer = 1;
            }
        }
        else
            shotTimer -= Time.deltaTime;
        {
        }
    }

	

    void Death()
    {
        Instantiate(Resources.Load("Prefab/Effects/Explosion"), transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyAttackObj")
        {
            health -= other.GetComponent<Damage>().damage;
            Destroy(other.gameObject);
        }
    }
}
