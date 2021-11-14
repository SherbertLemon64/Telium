using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TurnManager
{
    public static List<Enemy> Enemies = new List<Enemy>();
    public static List<Enemy> PendingAdditions = new List<Enemy>();
    public static List<Enemy> PendingRemovals = new List<Enemy>();
    
    public static void EnemyTurn()
    {
        foreach (Enemy e in Enemies)
        {
            e.Turn();
        }
        
        Enemies.AddRange(PendingAdditions);
        PendingAdditions.Clear();
        foreach (Enemy e in PendingRemovals)
        {
            Enemies.Remove(e);
        }
    }
}
