using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoInputListener2 : MonoBehaviour
{

	[SerializeField] private StringEventChannelSO _channel = null;

	private void OnEnable()
	{
		_channel?.AddListener(Respond);
	}

	private void OnDisable()
	{
		_channel?.RemoveListener(Respond);
	}

	private void Respond(string value)
	{
		Debug.Log("InputHappened2: " + value);
	}
}
