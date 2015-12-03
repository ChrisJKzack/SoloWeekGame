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
            for(int x = 0;x<transform.GetChildCount();x++)
            {
                transform.GetChild(x).transform.GetChild(0).GetComponent<Enemy>().StartMove();
            }
            moveOn = false;
        }
	}

    
}
