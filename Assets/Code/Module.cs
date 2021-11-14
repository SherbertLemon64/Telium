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
    public RoomEntity Occupier;

    void OnMouseDown()
    {
        if (Neighbours.Contains(Player.Instance.CurrentModule))
        {
            if (!(Occupier is null))
            {
                Occupier.GetEnterRoomCallback.Invoke(Player.Instance);
            }
            Player.Instance.Move(this);
        }
    }
    public Module RandomUnocupiedNeighbour()
    {
        List<Module> validPoints = new List<Module>();
        
        foreach (Module m in Neighbours)
        {
            if (m.Occupier is null)
            {
                validPoints.Add(m);
            } 
        }
        
        return validPoints.Count > 0 ? validPoints[Random.Range(0, validPoints.Count - 1)] : null;
    }
}
