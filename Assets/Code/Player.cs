using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Player : RoomEntity
{
	public static Player Instance;
	public int Health = 3;

	public float ViewingDist = 5.0f;
	
	public Module LastModule;

	public void Awake()
	{
		Instance = this;
	}

	public void Start()
	{
		GetEnterRoomCallback.AddListener(TakeDamage);
		Module start = MapManager.Instance.Modules[Random.Range(0, MapManager.Instance.Modules.Count)];
		while (!(start.Occupier is null))
		{
			start = MapManager.Instance.Modules[Random.Range(0, MapManager.Instance.Modules.Count)];
		}
		
		Move(start);
	}

	public new void Move(Module _moveTo)
	{
		if (!(CurrentModule is null))
		{
			LastModule = CurrentModule;
			CurrentModule.Occupier = null;
		}

		CurrentModule = _moveTo;
		CurrentModule.Occupier = this;
		transform.position = _moveTo.transform.position;

		TurnManager.EnemyTurn();
	}

	public void TakeDamage(RoomEntity _entity)
	{
		Health--;

		if (Health == 0)
		{
			SceneManager.LoadScene(3);
		}
	}
}
