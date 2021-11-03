using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class MotherAlien : MonoBehaviour, IRoomEntity
{
    public Module CurrentModule;

    public GameObject OffspringPrefab;
    public int Moves;
    
    private int spawnCountdown = 0;
    private const int TurnsToSpawn = 5;
    
    public UnityEvent<IRoomEntity> GetEnterRoomCallback() =>  null;
    
    public void Turn()
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
                Move(CurrentModule.RandomUnocupiedNeighbour());  
            }
        }

        spawnCountdown++;
    }

    public void SpawnOffspring()
    {
        Module spawnModule = CurrentModule.RandomUnocupiedNeighbour();
        
        GameObject offspring = Instantiate(OffspringPrefab);
        MiniAlien script = offspring.GetComponent<MiniAlien>();
        script.Move(spawnModule);
    }

    public void Move(Module _moveTo)
    {
        CurrentModule.Occupier = null;
        CurrentModule = _moveTo;
        CurrentModule.Occupier = this;
        transform.position = _moveTo.transform.position;
    }
}
