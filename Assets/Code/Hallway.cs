using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway : MonoBehaviour
{
	public Module[] Connections;
	public bool Enabled;
	public LineRenderer Renderer;

	public void Start()
	{
		gameObject.AddComponent<BoxCollider>();
	}

	public void OnMouseDown()
	{
		if (Enabled)
		{
			if (!(MapManager.Instance.DisabledHallway is null))
			{
				MapManager.Instance.DisabledHallway.Enable();
			}

			MapManager.Instance.DisabledHallway = this;
			Disable();
			Enabled = false;
		}
		else
		{
			Enable();
			Enabled = true;
		}
	}

	public void Enable()
	{
		Connections[0].Neighbours.Add(Connections[1]);
		Connections[1].Neighbours.Add(Connections[0]);
		Renderer.startColor = new Color(0.39f, 0.25f, 0.32f);
		Renderer.endColor = new Color(0.39f, 0.25f, 0.32f);
	}

	public void Disable()
	{
		Connections[0].Neighbours.Remove(Connections[1]);
		Connections[1].Neighbours.Remove(Connections[0]);
		Renderer.startColor = new Color(0.1992f,0.125f,0.16f);
		Renderer.endColor = new Color(0.1992f,0.125f,0.16f);
	}
}
