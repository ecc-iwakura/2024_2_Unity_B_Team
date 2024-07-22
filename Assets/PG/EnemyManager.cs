using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static List<Transform> allEnemies = new List<Transform>();

    public static void RegisterEnemy(Transform enemy)
    {
        allEnemies.Add(enemy);
    }

    public static void DeregisterEnemy(Transform enemy)
    {
        allEnemies.Remove(enemy);
    }
}
