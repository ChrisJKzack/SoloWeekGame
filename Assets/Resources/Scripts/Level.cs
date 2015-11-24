using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    public float levelLengthTime = 60;

    public float waveNumber = 6;

    public float waveSpawnTimer;
    public float waveSpawnIntervial;

    Vector3 startLocation;
    Vector3 targetLocation;

    bool triggerMove = false;
    bool moveOn = false;

    int movesLeft = 3;

    public Queue<Vector3> moveQueue = new Queue<Vector3>();

    GameObject formationGenerator;

	// Use this for initialization
	void Start ()
    {
        waveSpawnIntervial = levelLengthTime / waveNumber;
        waveSpawnTimer = waveSpawnIntervial;

        startLocation = transform.position;

        formationGenerator = GameObject.FindGameObjectWithTag("FormationGenerator");

        moveQueue.Enqueue(startLocation + new Vector3(1, 0, 0));
        moveQueue.Enqueue(startLocation + new Vector3(2, 0, 0));
        moveQueue.Enqueue(startLocation + new Vector3(3, 0, 0));

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


        if (moveOn)
        {
            
        }
	}

    void EndLevel()
    {

    }

    void SpawnWave()
    {
        formationGenerator.GetComponent<FormationGenerator>().SpawnRandomForamtion();
    }

    void Move()
    {
        transform.Translate(targetLocation * Time.deltaTime);

        if(targetLocation == transform.position)
        GoToNextTarget();
    }

    void StartMove()
    {

        moveOn = true;
    }

    void GoToNextTarget()
    {
        targetLocation = moveQueue.Dequeue();
        moveQueue.Enqueue(targetLocation);
        movesLeft--;
    }
}
