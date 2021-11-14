using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class RoomEntity : MonoBehaviour
{
    public Module CurrentModule;
    public void Move(Module _moveTo)
    {
        if (!(CurrentModule is null))
        {
            CurrentModule.Occupier = null;
        }
        CurrentModule = _moveTo;
        CurrentModule.Occupier = this;
        transform.position = _moveTo.transform.position;
    }
    
   
    public UnityEvent<RoomEntity> GetEnterRoomCallback = new UnityEvent<RoomEntity>();
}
