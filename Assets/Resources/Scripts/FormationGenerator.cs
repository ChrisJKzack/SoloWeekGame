using UnityEngine;
using System.Collections;

public class FormationGenerator : MonoBehaviour {


     void SpawnFormation(int EnemiesInFormation, float SeperationX, float SeperationY,float StartX,float StartY)
    {
        GameObject formation = Instantiate(Resources.Load("Prefab/Formation/Formation"), new Vector3(StartX, StartY, 0), Quaternion.identity) as GameObject;

        bool right = false;
        //if odd
        if (EnemiesInFormation % 2 != 0)
        {
            GameObject middlePosition = Instantiate(Resources.Load("Prefab/Formation/Position"), new Vector3(StartX, StartY, 0), Quaternion.identity) as GameObject;

            middlePosition.transform.SetParent(formation.transform);

            


            //first ship already made
            for (int x =1; EnemiesInFormation > x; x++)
            {
                if (right)
                {
                    GameObject position = Instantiate(Resources.Load("Prefab/Formation/Position"), new Vector3(middlePosition.transform.position.x + SeperationX * ((x + 1) / 2), middlePosition.transform.position.y + SeperationY * ((x + 1) / 2), 0), Quaternion.identity) as GameObject;

                    position.transform.SetParent(formation.transform);

                    right = !right;
                }
                else
                {
                    GameObject position = Instantiate(Resources.Load("Prefab/Formation/Position"), new Vector3(middlePosition.transform.position.x - SeperationX * ((x + 1) / 2), middlePosition.transform.position.y + SeperationY * ((x + 1) / 2), 0), Quaternion.identity) as GameObject;
                    position.transform.SetParent(formation.transform);

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
                    GameObject position = Instantiate(Resources.Load("Prefab/Formation/Position"), new Vector3(StartX + SeperationX * ((x + 1) / 2), StartY + SeperationY * ((x + 1) / 2), 0), Quaternion.identity) as GameObject;

                    position.transform.SetParent(formation.transform);

                    right = !right;
                }
                else
                {
                    GameObject position = Instantiate(Resources.Load("Prefab/Formation/Position"), new Vector3(StartX - SeperationX * ((x + 1) / 2), StartY + SeperationY * ((x + 1) / 2), 0), Quaternion.identity) as GameObject;
                    position.transform.SetParent(formation.transform);

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

    public void AddEnemiesToFormation(Transform Formation)
    {
        foreach(Transform child in Formation)
        {
            GameObject enemy = Instantiate(Resources.Load("Prefab/Enemy/EnemyOne"),child.position,Quaternion.identity) as GameObject;

           enemy.transform.SetParent(child);
           enemy.GetComponent<Animator>().Play("ArrivalRight");
        }
        
    }


}
