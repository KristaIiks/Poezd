using UnityEngine;
using PathCreation;
using UnityEngine.XR.Content.Interaction;

public class PathFollower : MonoBehaviour
{
	[SerializeField] private PathCreator _path;
	[SerializeField] private float _pos;
	[SerializeField] private float _speed = 10f;
	[SerializeField] private EndOfPathInstruction endOfPathInstruction;
	[SerializeField] private XRKnob _leveler;
	[SerializeField] private AudioSource _audio;
	private float _maxPos;
	private bool _isStarted;
	
	private void Awake()
	{
		_maxPos = _path.path.length + (_pos - 70f);
	}
	
	private void OnEnable()
	{
		Train.Instance._onEngine += Engine;
	}
	
	private void OnDisable()
	{
		Train.Instance._onEngine -= Engine;
	}
	
	private void Update()
	{
		CalculateSpeed();
		
		if (_path != null && _pos < _maxPos)
		{
			_pos += _speed * Time.deltaTime;
			
			var _targetPos = _path.path.GetPointAtDistance(_pos, endOfPathInstruction);
			var _targetRot = _path.path.GetRotationAtDistance(_pos, endOfPathInstruction);
			
			transform.position = new Vector3(_targetPos.x, transform.position.y, _targetPos.z);
			transform.rotation = Quaternion.Euler(transform.rotation.x, _targetRot.eulerAngles.y - 90f, transform.rotation.z);
		}
	}
	
	private void CalculateSpeed()
	{
		if(!_isStarted) { _speed = 0f; return; }
		
		_speed = _leveler.value * 10f;
	}
	
	public void Engine(bool _state)
	{
		if(_state == false)
		{
			_speed = 0f;
			
			if(_audio != null)
			{
				_audio.Play();
			}
		}
		else
		{
			if(_audio != null)
			{
				_audio.Stop();
			}
		}
		
		_isStarted = _state;
	}
}
