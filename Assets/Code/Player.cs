using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Player : RoomEntity
{
	public static Player Instance;
	public int Health = 3;

	public Module LastModule;

	public void Awake()
	{
		Instance = this;
	}

	public void Start()
	{
		GetEnterRoomCallback.AddListener(TakeDamage);
		Move(FindObjectOfType<Module>());
	}

	public new void Move(Module _moveTo)
	{
		if (!(LastModule is null))
		{
			LastModule.Occupier = null;
		}
		if (!(CurrentModule is null))
		{
			LastModule = CurrentModule;
		}

		CurrentModule = _moveTo;
		CurrentModule.Occupier = this;
		transform.position = _moveTo.transform.position;

		TurnManager.EnemyTurn();
	}

	public void TakeDamage(RoomEntity _entity)
	{
		Health--;
	}
}
