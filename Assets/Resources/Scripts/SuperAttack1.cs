using UnityEngine;
using System.Collections;

public class SuperAttack1 : MonoBehaviour {
    float timer = 2;
    float factor = 15;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer > 0)
        {
            transform.localScale += new Vector3(Time.deltaTime * factor, Time.deltaTime * factor, 0);
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().health -= 100;
        }
    }
}
