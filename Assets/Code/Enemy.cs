using UnityEngine;

public abstract class Enemy : RoomEntity
{
	public SpriteRenderer Renderer;
	public abstract void Turn();

	virtual public void Kill()
	{
		TurnManager.PendingRemovals.Add(this);
		Destroy(gameObject);
	}
	
	public void CheckIfSeen()
	{
		Vector3 distToPlayer = Player.Instance.transform.position - transform.position;

		Renderer.enabled = distToPlayer.magnitude <= Player.Instance.ViewingDist;
	}
}
