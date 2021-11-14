using UnityEngine;

public abstract class Enemy : RoomEntity
{
	public abstract void Turn();

	virtual public void Kill()
	{
		TurnManager.PendingRemovals.Add(this);
		Destroy(gameObject);
	}
}
