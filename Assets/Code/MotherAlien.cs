using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class MotherAlien : Enemy
{
    public GameObject OffspringPrefab;
    public int Moves;
    
    private int spawnCountdown = 0;
    private const int TurnsToSpawn = 5;

    public void Start()
    {
        TurnManager.Enemies.Add(this);
        GetEnterRoomCallback.AddListener(Attacked);
        // just grab some random room for now, optimize this later maybe idk
        Move(MapManager.Instance.Modules[Random.Range(0,MapManager.Instance.Modules.Count)]);
    }

    public override void Turn()
    {
        if (spawnCountdown >= TurnsToSpawn)
        {
            SpawnOffspring();
            spawnCountdown = 0;
        }
        else
        {
            for (int i = 0; i < Moves; i++)
            {
                Module move = CurrentModule.RandomUnocupiedNeighbour();
                if (!(move is null))
                {
                    Move(move);  
                }
            }
        }

        spawnCountdown++;
    }

    public void SpawnOffspring()
    {
        Module spawnModule = CurrentModule.RandomUnocupiedNeighbour();

        if (spawnModule == null)
        {
            return;
        }
        
        GameObject offspring = Instantiate(OffspringPrefab);
        MiniAlien script = offspring.GetComponent<MiniAlien>();
        TurnManager.PendingAdditions.Add(script);
        
        script.Move(spawnModule);
    }

    public void Attacked(RoomEntity _entity)
    {
        if (_entity is Player)
        {
            Module runTo = CurrentModule.RandomUnocupiedNeighbour();
            if (runTo == null)
            {
                Destroy(gameObject);
            }
        }
    }
}
