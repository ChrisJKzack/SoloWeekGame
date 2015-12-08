using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Formation : MonoBehaviour {

    public bool moveOn = false;
    public Dictionary<int, Vector3> moveQueue = new Dictionary<int, Vector3>();
    public List<Enemy> enemiesInFormation;

    // Use this for initialization
    void Start ()
    {
        CreateEnemyList();
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
            foreach (Enemy enemy in enemiesInFormation)
            {
                enemy.StartMove();
            }
            moveOn = false;
        }
	}

    public void GetRandomPath()
    {
        moveQueue = EnemyMapping.CreateRandomPathForFormation(enemiesInFormation, 3);
    }

    void CreateEnemyList()
    {
        for (int x = 0; x < transform.GetChildCount(); x++)
        {
            enemiesInFormation.Add(transform.GetChild(x).transform.GetChild(0).GetComponent<Enemy>());
        }
    }



}
