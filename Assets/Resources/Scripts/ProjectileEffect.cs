using UnityEngine;
using System.Collections;

public class ProjectileEffect : MonoBehaviour {


	// Update is called once per frame
	void Update ()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            Destroy(gameObject);
        }
	}
}
