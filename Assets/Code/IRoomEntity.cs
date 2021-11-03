using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IRoomEntity
{
    Color GetColor();
    Sprite GetSprite();
    UnityEvent<IRoomEntity> GetEnterRoomCallback();
}
