using UnityEngine;
using System.Collections;

public class Formation : MonoBehaviour {

    public bool moveOn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }

        if (moveOn)
        {
            foreach (Transform t in transform.GetChild(0).transform)
            {
                //TODO make it find the child and turn on each start move
                transform.GetComponent<Enemy>().StartMove();
            }
            moveOn = false;
        }
	}

    
}
