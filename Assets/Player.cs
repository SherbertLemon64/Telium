using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player Instance;
	public Module ModuleOn;

	public void Start()
	{
		Instance = this;
	}

	public void Move(Module _moveTo)
	{
		ModuleOn = _moveTo;
		transform.position = _moveTo.transform.position;
	}

}
