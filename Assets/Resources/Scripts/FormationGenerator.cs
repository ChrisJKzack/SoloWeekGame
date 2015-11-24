using UnityEngine;
using System.Collections;

public class FormationGenerator : MonoBehaviour {

    int enemyShipCount = 0;


     void SpawnFormation(int EnemiesInFormation, float SeperationX, float SeperationY,float StartX,float StartY)
    {
        GameObject formation = Instantiate(Resources.Load("Prefab/Formation/Formation"), new Vector3(StartX, StartY, 0), Quaternion.identity) as GameObject;

        bool right = false;
        //if odd
        if (EnemiesInFormation % 2 != 0)
        {
            CreatePosition(StartX, StartY, formation.transform);



            //first ship already made
            for (int x =1; EnemiesInFormation > x; x++)
            {
                if (right)
                {
                    CreatePosition(StartX + SeperationX * ((x + 1) / 2), StartY + SeperationY * ((x + 1) / 2), formation.transform);
                    right = !right;
                }
                else
                {

                    CreatePosition(StartX - SeperationX * ((x + 1) / 2), StartY + SeperationY * ((x + 1) / 2), formation.transform);
                    right = !right;
                }
            }
        }
        //if even
        else
        {

            for (int x = 1; EnemiesInFormation > x-1; x++)
            {
                if (right)
                {
                    CreatePosition(StartX + SeperationX * ((x + 1) / 2), StartY + SeperationY * ((x + 1) / 2), formation.transform);
                    right = !right;
                }
                else
                {
                    CreatePosition(StartX - SeperationX * ((x + 1) / 2), StartY + SeperationY * ((x + 1) / 2), formation.transform);
                    right = !right;
                }
            }
        }
        AddEnemiesToFormation(formation.transform);
    }


    public void SpawnSomethings()

    { 
        SpawnFormation(3, 2, 2, 0, 0);
    }

    void AddEnemiesToFormation(Transform Formation)
    {
        foreach(Transform child in Formation)
        {
            GameObject enemy = Instantiate(Resources.Load("Prefab/Enemy/1"), child.position, Quaternion.identity) as GameObject;
            enemy.transform.SetParent(child);
        }
        
    }

    public void SpawnRandomForamtion()
    {
        SpawnFormation(Random.Range(1, 6), Random.Range(1, 4),Random.Range(1, 7),Random.Range(-6,6) +.5f, Random.Range(-2,5) +.5f);
    }

    void checkIfPositionAvaliable()
    {

    }


    void CreatePosition(float PosX,float PosY, Transform Formation)
    {
        if (EnemyMapping.InboundsAndEmpty(PosX, PosY))
        {
            GameObject position = Instantiate(Resources.Load("Prefab/Formation/Position"), new Vector3(PosX, PosY, 0), Quaternion.identity) as GameObject;
            position.transform.SetParent(Formation);
            enemyShipCount++;
            position.name = enemyShipCount.ToString();
            EnemyMapping.SetToMap(position.transform.position.x, position.transform.position.y, position.name);
        }
    }
    
    public void Bomb()
    {
        
    }



}
