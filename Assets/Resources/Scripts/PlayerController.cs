using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    float moveFactor = 2;
    float shotTimer = .5f;
    float health = 20;
    int superAttackNumberLoaded = 1;

    public int missleCount = 3;

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
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
    }

    void ShotManager()
    {
        if (shotTimer <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject laser = Instantiate(Resources.Load("Prefab/Player/Laser"), transform.position + new Vector3(0, .5f, 0), Quaternion.identity) as GameObject;
                shotTimer = .5f;
            }
        }
        else
            shotTimer -= Time.deltaTime;
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

    public void ShootLaser()
    {
        GameObject laser = Instantiate(Resources.Load("Prefab/Player/Laser"), transform.position + new Vector3(0, .5f, 0), Quaternion.identity) as GameObject;
    }

    public void ShootMissle()
    {
        if (missleCount > 0)
        {
            GameObject missle = Instantiate(Resources.Load("Prefab/Player/Missle"), transform.position + new Vector3(0, .5f, 0), Quaternion.identity) as GameObject;
            missleCount--;
        }
    }

    public void MoveLeft()
    {
        transform.position = new Vector2(transform.position.x - Time.deltaTime * moveFactor, transform.position.y);
    }

    public void MoveRight()
    {
        transform.position = new Vector2(transform.position.x + Time.deltaTime * moveFactor, transform.position.y);
    }

    public void SuperMove()
    {
        if (superAttackNumberLoaded != 0)
        {
            GameObject superAttack = Instantiate(Resources.Load("Prefab/Player/SuperAttack/" + superAttackNumberLoaded), transform.position + new Vector3(0, .5f, 0), Quaternion.identity) as GameObject;
        }
    }

    public void LoadSuperMove(int SuperAttackNumber)
    {
        superAttackNumberLoaded = SuperAttackNumber;
    }

}


