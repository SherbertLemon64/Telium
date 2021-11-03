using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiniAlien : MonoBehaviour, IRoomEntity
{
    public Module CurrentModule;

    public void Turn()
    {
        Vector3 distToPlayer = Player.Instance.transform.position - transform.position;
        
        // unfinished
    }
    
    public void Move(Module _moveTo)
    {
        CurrentModule.Occupier = null;
        CurrentModule = _moveTo;
        CurrentModule.Occupier = this;
        transform.position = _moveTo.transform.position;
    }
    
    public UnityEvent<IRoomEntity> GetEnterRoomCallback() =>  null;
}
