﻿using UnityEngine;
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

    public static bool PathAvaliable(Enemy Enemy, Dictionary<int, Vector3> MoveQueue)
    {

        for (int i = 0; i < MoveQueue.Count; i++)
        {
            if (!MapEmpty(Enemy.startLocation.x + MoveQueue[i].x, Enemy.startLocation.y + MoveQueue[i].y))
                return false;
        }

        return true;
    }

    public static void SetPath(Enemy Enemy, Dictionary<int, Vector3> MoveQueue)
    {

        for (int i = 0; i < MoveQueue.Count; i++)
        {
            SetToMap(MoveQueue[i].x, MoveQueue[i].y, Enemy.name + "m" + i);
        }
    }

    public static void SetPathIfAvaliable(Enemy Enemy, Dictionary<int, Vector3> MoveQueue)
    {
        if (PathAvaliable(Enemy, MoveQueue))
        {
            SetPath(Enemy, MoveQueue);
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

    public Dictionary<int, Vector3> CreateRandomPathForFormation(Enemy[] EnemiesInFormation,int LengthOfPath)
    {

        int lengthOfPath = LengthOfPath;

        bool pathCreated = false;
        int elementInDictionary = 0;

        Dictionary<int, Vector3> movePath = new Dictionary<int, Vector3>();

        //puts starting position at begging of movePath
        for (int x = 0; x < EnemiesInFormation.Length; x++)
            movePath.Add(0, EnemiesInFormation[x].startLocation);


        while (pathCreated == false)
        {
            while (lengthOfPath > elementInDictionary)
            {
                bool leftAvaliable = true;
                bool rightAvaliable = true;
                bool upAvaliable = true;
                bool downAvaliable = true;

                bool upLeftAvaliable = true;
                bool upRightAvaliable = true;
                bool downLeftAvaliable = true;
                bool downRightAvaliable = true;

                foreach (Enemy enemy in EnemiesInFormation)
                {
                    Vector3 currentPos = enemy.startLocation;

                    for (int x = 0; x < movePath.Count; x++)
                    {
                        if (x != 0)
                        {
                            currentPos += movePath[elementInDictionary];
                        }
                    }
                    //cardinal avaliable
                    if (!InboundsAndEmpty(currentPos.x - 1, currentPos.y))
                        leftAvaliable = false;
                    if (!InboundsAndEmpty(currentPos.x + 1, currentPos.y))
                        rightAvaliable = false;
                    if (!InboundsAndEmpty(currentPos.x, currentPos.y+1))
                        upAvaliable = false;
                    if (!InboundsAndEmpty(currentPos.x, currentPos.y-1))
                        downAvaliable = false;
                    //Diagnoal avaliable
                    if (!InboundsAndEmpty(currentPos.x - 1, currentPos.y +1))
                        upLeftAvaliable = false;
                    if (!InboundsAndEmpty(currentPos.x + 1, currentPos.y +1))
                        upRightAvaliable = false;
                    if (!InboundsAndEmpty(currentPos.x - 1, currentPos.y -1))
                        downLeftAvaliable = false;
                    if (!InboundsAndEmpty(currentPos.x +1, currentPos.y -1))
                        downRightAvaliable = false;

                }


            }
        }
        return movePath;
    }
        


    

}
