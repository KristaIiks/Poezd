using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OutlineBtns : MonoBehaviour
{
	[SerializeField] private Color _startColor;
	[SerializeField] private Color _activeColor;
	[SerializeField] private XRSimpleInteractable _intr;
	
	private bool _activated;
	

	private void OnEnable()
	{
		Train.Instance._onEngine += Engine;
	}
	
	private void OnDisable()
	{
		Train.Instance._onEngine -= Engine;
	}
	
	private void Engine(bool _state)
	{
		_intr.enabled = _state;
	}
	
	public void ChangeBtnState()
	{
		_activated = !_activated;
	}
}
