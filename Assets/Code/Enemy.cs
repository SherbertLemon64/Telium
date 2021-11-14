using UnityEngine;

public abstract class Enemy : RoomEntity
{
	public abstract void Turn();

	public void Kill()
	{
		TurnManager.PendingRemovals.Add(this);
		Destroy(gameObject);
	}
}
