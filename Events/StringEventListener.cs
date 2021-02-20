using UnityEngine;
using UnityEngine.Events;

public class StringEventListener : MonoBehaviour
{
	[SerializeField] private StringEventChannelSO _channel = default;

	public UnityEvent<string> OnEventRaised;

	private void OnEnable()
	{
		if (_channel != null)
			_channel.OnEventRaised += Respond;
	}

	private void OnDisable()
	{
		if (_channel != null)
			_channel.OnEventRaised -= Respond;
	}

	private void Respond(string value)
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke(value);
	}
}
