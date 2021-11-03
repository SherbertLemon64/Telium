using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    public List<int> BlockedPaths;
    public ModuleComponent Component;
    public List<Module> Neighbours = new List<Module>();
    [SerializeField] private SpriteRenderer occupierRenderer;

    public IRoomEntity _occupier;
    public IRoomEntity occupier {
        set {
            _occupier = value;

            if (occupier != null)
            {
                occupierRenderer.color = occupier.GetColor();
                occupierRenderer.sprite = occupier.GetSprite();
            } else
            {
                occupierRenderer.color = Color.clear;
                occupierRenderer.sprite = null;
            }
        } get => _occupier;
    }

    void OnMouseDown()
    {
        if (Neighbours.Contains(Player.Instance.ModuleOn))
        {
            Player.Instance.Move(this);
            if (occupier != null)
                if (occupier.GetEnterRoomCallback() != null)
                    occupier.GetEnterRoomCallback().Invoke(Player.Instance);
        }
    }
}
