using UnityEngine;
using System.Collections;

public class EnemyMapping : MonoBehaviour {

   public static string[,] enemyMap = new string[7, 12];


    public static bool MapEmpty(float X, float Y)
    {
        int x = (int)(X + 5.5f);
        int y = (int)(Y + 1.5f);

        if (enemyMap[y,x] == null)
            return true;
        else
            return false;
       
    }

    public static void SetMap(float X, float Y,string fill)
    {
        int x = (int)(X + 5.5f);
        int y = (int)(Y + 1.5f);

        Debug.Log(x + "  " + y);

        enemyMap[y,x] = fill;
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

}
