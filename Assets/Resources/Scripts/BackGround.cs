using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackGround : MonoBehaviour {
    public float scrollSpeed = 1;
    Transform frame1, frame2, frame3;
    List<Transform> frames;

    void Start()
    {
        frame1 = transform.GetChild(0);
        frame2 = transform.GetChild(1);
        frame3 = transform.GetChild(2);
    }
	// Update is called once per frame
	void Update ()
    {
        Scroll();
	}

    void Scroll()
    {
        foreach (Transform frame in transform)
        {
            frame.Translate(new Vector3(0, -scrollSpeed * Time.deltaTime, 0));

            if (frame.position.y <= -10)
            {
                frame.position += new Vector3(0, 30, 0);
            }
        }
    }
}
