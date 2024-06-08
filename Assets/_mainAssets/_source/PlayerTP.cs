using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerTP : MonoBehaviour
{	
	public void TP(Transform _pos)
	{
		transform.SetParent(_pos);
		GetComponentInChildren<TeleportationProvider>().QueueTeleportRequest(new TeleportRequest
        {
            destinationPosition = _pos.position,
            destinationRotation = _pos.rotation
        });
	}
}
