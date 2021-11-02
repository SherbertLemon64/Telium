using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    public List<int> BlockedPaths;
    public ModuleComponent Component;
    public List<Module> Neighbours = new List<Module>();
    //public IEnemy EnemyOn;
    
    public void OnMouseDown()
    {
        if (Neighbours.Contains(Player.Instance.ModuleOn))
        {
            Player.Instance.Move(this);
        }
    }

}
