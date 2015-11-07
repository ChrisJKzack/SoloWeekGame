using UnityEngine;
using System.Collections;

public class FormationGenerator : MonoBehaviour {


     void SpawnFormation(int EnemiesInFormation, float SeperationX, float SeperationY,float StartX,float StartY)
    {
        GameObject formation = Instantiate(Resources.Load("Prefab/Formation/Formation"), new Vector3(StartX, StartY, 0), Quaternion.identity) as GameObject;

        //if odd
        if (EnemiesInFormation % 2 != 0)
        {
            GameObject middlePosition = Instantiate(Resources.Load("Prefab/Formation/Position"), new Vector3(StartX, StartY, 0), Quaternion.identity) as GameObject;

            middlePosition.transform.SetParent(formation.transform);

            bool right = false;


            //first ship already made
            for (int x =1; EnemiesInFormation > x; x++)
            {
                Debug.Log("run");
                if (right)
                {
                    GameObject position = Instantiate(Resources.Load("Prefab/Formation/Position"), new Vector3(middlePosition.transform.position.x + SeperationX * ((x + 1) / 2), middlePosition.transform.position.y + SeperationY * ((x + 1) / 2), 0), Quaternion.identity) as GameObject;

                    position.transform.SetParent(formation.transform);

                    right = !right;
                }
                else
                {
                    GameObject position = Instantiate(Resources.Load("Prefab/Formation/Position"), new Vector3(middlePosition.transform.position.x - SeperationX * ((x + 1) / 2), middlePosition.transform.position.y + SeperationY * ((x + 1) / 2), 0), Quaternion.identity) as GameObject;
                    position.transform.name = "left";
                    position.transform.SetParent(formation.transform);

                    right = !right;
                }
            }
        }
        else
        {

        }
    }


    public void SpawnSomethings()
    {
        SpawnFormation(5, 2, 2, 0, 0);
    }
}
