using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Module : MonoBehaviour
{
    public List<int> BlockedPaths;
    public ModuleComponent Component;
    public List<Module> Neighbours = new List<Module>();
    public IRoomEntity Occupier;

    void OnMouseDown()
    {
        if (Neighbours.Contains(Player.Instance.CurrentModule))
        {
            Player.Instance.Move(this);
            if (Occupier != null)
                if (Occupier.GetEnterRoomCallback() != null)
                    Occupier.GetEnterRoomCallback().Invoke(Player.Instance);
        }
    }
    public Module RandomUnocupiedNeighbour()
    {
        List<Module> spawnPoints = new List<Module>(Neighbours);
        foreach (Module m in spawnPoints)
        {
            if (false) // if it has an entity in it (code being written) 
            {
                spawnPoints.Remove(m);
            } 
        }
        
        return spawnPoints[Random.Range(0, spawnPoints.Count - 1)];
    }
}
