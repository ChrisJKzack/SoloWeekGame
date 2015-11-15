using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissleText : MonoBehaviour {

	// Update is called once per frame
	void Update ()
    {
        GetComponent<Text>().text = "Missles: " + GameObject.Find("Player").GetComponent<PlayerController>().missleCount;
	}
}
