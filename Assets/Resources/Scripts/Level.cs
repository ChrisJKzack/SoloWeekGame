using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    public float levelLengthTime = 60;

    public float waveNumber = 6;

    public float waveSpawnTimer;
    public float waveSpawnIntervial;

    GameObject formationGenerator;

	// Use this for initialization
	void Start ()
    {
        waveSpawnIntervial = levelLengthTime / waveNumber;
        waveSpawnTimer = waveSpawnIntervial;

        formationGenerator = GameObject.FindGameObjectWithTag("FormationGenerator");
	}
	
	// Update is called once per frame
	void Update ()
    {
        levelLengthTime -= Time.deltaTime;
        waveSpawnTimer -= Time.deltaTime;

        if (levelLengthTime == 0)
            EndLevel();

        if (waveSpawnTimer <= 0)
        {
            SpawnWave();
            waveSpawnTimer = waveSpawnIntervial;
        }

	}

    void EndLevel()
    {

    }

    void SpawnWave()
    {
        formationGenerator.GetComponent<FormationGenerator>().SpawnRandomForamtion();
    }
}
