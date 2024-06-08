using System;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class Train : MonoBehaviour
{
	[SerializeField] private XRKnob _key;
	public Action<bool> _onEngine;
	public static Train Instance
	{
		get
		{
			m_Instanse ??= FindObjectOfType<Train>();
			return m_Instanse;
		}
	}
	private static Train m_Instanse;
	
	private void Awake()
	{
		_key.onValueChange.AddListener(CheckEngine);
	}
	
	bool _lastValue;
	private void CheckEngine(float value)
	{
		bool _value = ValueCheck.CheckValue(_key);
		if(_lastValue != _value)
		{
			_onEngine?.Invoke(_value);
		}
		_lastValue = _value;
	}
}
