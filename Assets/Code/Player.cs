using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IRoomEntity
{
	public static Player Instance;
	public Module ModuleOn;

    [SerializeField] private Color color;
    [SerializeField] private Sprite sprite;

	public void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		// just grab some random room for now, optimize this later maybe idk
		Move(FindObjectOfType<Module>());
	}

	public void Move(Module _moveTo)
	{
		ModuleOn.occupier = null;
		ModuleOn = _moveTo;
		ModuleOn.occupier = this;
		transform.position = _moveTo.transform.position;
	}

	public Color GetColor() => color;

	public Sprite GetSprite() => sprite;

    public UnityEvent<IRoomEntity> GetEnterRoomCallback() =>  null;
}
