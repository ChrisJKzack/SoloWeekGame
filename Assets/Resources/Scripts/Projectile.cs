using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float shotSpeed;
    public float damage;
    bool dead = false;



    public virtual void FixedUpdate()
    {
        if(!dead)
        transform.Translate(new Vector3(0, Time.deltaTime * shotSpeed, 0));
    }

    public virtual void Update()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Enemy")
        {

            other.GetComponent<Enemy>().health -= damage;
            EnemyHit();
        }

        if (other.tag == "Shredder")
        {
            Destroy(gameObject);
        }

        if (other.tag == "Super")
        {
            SuperHit();
        }
    }

    public virtual void EnemyHit()
    {
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<Animator>().SetTrigger("Hit");
        dead = true;
    }

    public virtual void SuperHit()
    {
        Debug.Log("test");
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<Animator>().SetTrigger("Super");
        dead = true;
    }


}
