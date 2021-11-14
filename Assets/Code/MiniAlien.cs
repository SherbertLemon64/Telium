using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiniAlien : Enemy
{
    public void Start()
    {
        GetEnterRoomCallback.AddListener(PlayerAttack);
    }

    public override void Turn()
    {
        Vector3 distToPlayer = Player.Instance.transform.position - transform.position;

        Vector3 difference = Math.Abs(distToPlayer.x) > Math.Abs(distToPlayer.y)
            ? Vector3.right * Math.Sign(distToPlayer.x) * 2.5f
            : Vector3.up * Math.Sign(distToPlayer.y) * 2.5f;
            
        Module find = CurrentModule.Neighbours.Find((Module module) => module.transform.position == transform.position + difference);
        
        if (find is null || find.Occupier ! is null && (Player)find.Occupier != Player.Instance)
        {
            find = CurrentModule.RandomUnocupiedNeighbour();

            if (find is null) { return; }
        }
        
        
        if (find.Occupier == Player.Instance)
        {
            find.Occupier.GetEnterRoomCallback.Invoke(this);
        } else
        {
            Move(find);
        }
    }

    public void PlayerAttack(RoomEntity _entity)
    {
        if (_entity is Player)
        {
            Kill();
        }
    }
}
