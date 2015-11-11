using UnityEngine;
using System.Collections;

public class EnemyMapping : MonoBehaviour {

   public static string[,] enemyMap = new string[9, 12];


    public static bool MapEmpty(int x, int y)
    {
        if (enemyMap[y,x] == null)
            return true;
        else
            return false;
       
    }

    public static void SetMap(float X, float Y,string fill)
    {
        Debug.Log(X+ "  " +Y);

        enemyMap[(int)(Y * 2), (int)X] = fill;
    }

}
