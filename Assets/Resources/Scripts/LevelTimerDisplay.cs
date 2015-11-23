using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTimerDisplay : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.GetComponent<Text>().text = "Level Timer: " + GameObject.Find("LevelManager").GetComponent<LevelManager>().currentLevel.levelLengthTime.ToString("#.##");
	}
}
