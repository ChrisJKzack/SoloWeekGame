using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

    float shotTimer = 1;
    bool leftShot = true;
    public float health = 20;
    bool dead = false;
    public bool stationary;

   public Vector3 startLocation;
   public Vector3 targetLocation;

    bool triggerMove = false;
    bool moveOn = false;

    float moveFactor = 1;

    int movesLeft = 3;



    Queue<Vector3> moveQueue = new Queue<Vector3>();


    void Start()
    {
        startLocation = transform.position;

        moveQueue.Enqueue(startLocation);
        moveQueue.Enqueue(startLocation + new Vector3(1, 0, 0));
        moveQueue.Enqueue(startLocation);
        moveQueue.Enqueue(startLocation + new Vector3(-1, 0, 0));
    }

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
                EnemyMapping.RemoveFromMap(transform.parent.transform.position.x, transform.parent.transform.position.y);
                Destroy(transform.parent.gameObject);
            }
        }

    }

    void FixedUpdate()
    {
        if (!dead)
        {
            if (moveOn)
            {
                Move();
            }
        }

    }

    void Move()
    {
        Debug.Log("test");



        transform.position = Vector3.MoveTowards(transform.position, targetLocation, Time.deltaTime);
       
        // transform.Translate(targetLocation * Time.deltaTime);


        
        if (targetLocation == transform.position)
            GoToNextTarget();
        
    }

    public void StartMove()
    {

        moveOn = true;
        GoToNextTarget();
    }

    void GoToNextTarget()
    {
        targetLocation = moveQueue.Dequeue();
        moveQueue.Enqueue(targetLocation);
        movesLeft--;
    }

}
