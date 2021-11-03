using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "RoomEntity", menuName = "Scriptables/Room Entity", order = 1)]
class RoomEntity : ScriptableObject, IRoomEntity
{
    public Sprite sprite;
    public Color color;
    public UnityEvent<IRoomEntity> enterCallback;

    public Color GetColor() => color;

    public UnityEvent<IRoomEntity> GetEnterRoomCallback() => enterCallback;

    public Sprite GetSprite() => sprite;

}