using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IRoomEntity
{
	public static Player Instance;
	public Module CurrentModule;

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
		CurrentModule.Occupier = null;
		CurrentModule = _moveTo;
		CurrentModule.Occupier = this;
		transform.position = _moveTo.transform.position;
	}

	public UnityEvent<IRoomEntity> GetEnterRoomCallback() =>  null;
}
