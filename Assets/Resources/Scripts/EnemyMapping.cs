using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMapping : MonoBehaviour {

   public static string[,] enemyMap = new string[7, 12];
    Transform[,] debuggingMap = new Transform[7, 12];
    public bool deBugOn = true;

    void Start()
    {

        //Deubgging
        if (deBugOn)
        {
            for (int x = 0; x < enemyMap.GetLength(1); x++)
            {
                for (int y = 0; y < enemyMap.GetLength(0); y++)
                {
                    debuggingMap[y, x] = transform.GetChild(0).transform.GetChild(y).transform.GetChild(x);
                }
            }
        }
    }

    void Update()
    {
        //Debugging
        if(deBugOn)
        DebuggingMap();
    }


    public static bool MapEmpty(float X, float Y)
    {
        int x = (int)(X + 5.5f);
        int y = (int)(Y + 1.5f);

        if (enemyMap[y,x] == null)
            return true;
        else
            return false;
       
    }

    public static void SetToMap(float X, float Y,string fill)
    {
        int x = (int)(X + 5.5f);
        int y = (int)(Y + 1.5f);
        enemyMap[y,x] = fill;
    }

    public static void RemoveFromMap(float X, float Y)
    {
        int x = (int)(X + 5.5f);
        int y = (int)(Y + 1.5f);
        enemyMap[y, x] = null;
    }

    public static bool Inbounds(float X, float Y)
    {
        int x = (int)(X + 5.5f);
        int y = (int)(Y + 1.5f);

        if (x >= 0 && x <= 11)
        {
            if (y >= 0 && y <= 6)
            {
                return true;
            }
        }

        return false;
    }

    public static bool InboundsAndEmpty(float X, float Y)
    {
        if (Inbounds(X, Y) && MapEmpty(X, Y))
        {
            return true;
        }
        else
        return false;
    }

    void GenerateEnemyPath()
    {

    }

    bool PathAvaliable(Enemy Enemy, Queue<Vector3> Path)
    {

        for (int i = Path.Count; i >= 0; i--)
        {
            Vector3 targetPos = Path.Dequeue();
            Path.Enqueue(targetPos);

            if (!MapEmpty(Enemy.startLocation.x + targetPos.x, Enemy.startLocation.x + targetPos.y))
            {
                return false;
            }
        }
        return true;
    }

    public static void SetPath(Enemy Enemy, Dictionary<int, Vector3> MoveQueue)
    {
        /*
        for (int i = Path.Count; i >= 0; i--)
        {
            Vector3 targetPos = Path.Dequeue();
            Path.Enqueue(targetPos);

            if (!MapEmpty(Enemy.startLocation.x + targetPos.x, Enemy.startLocation.x + targetPos.y))
            {
                SetToMap(Enemy.startLocation.x + targetPos.x, Enemy.startLocation.x + targetPos.y, Enemy.name + "m");
            }
        }
        */
        for (int i = 0; i < MoveQueue.Count; i++)
        {
            SetToMap(MoveQueue[i].x, MoveQueue[i].y, Enemy.name + "m" + i);
        }



    }

    void DebuggingMap()
    {
        for (int x = 0; x < enemyMap.GetLength(1); x++)
        {
            for (int y = 0; y < enemyMap.GetLength(0); y++)
            {
                if (enemyMap[y, x] != null)
                {
                    debuggingMap[y, x].GetComponent<MapDebugging>().filled = enemyMap[y, x];
                }
            }
        }
    }
        


    

}
