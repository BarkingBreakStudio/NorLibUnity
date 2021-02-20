using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class StringEventListener : MonoBehaviour
{
	[SerializeField] private StringEventChannelSO _channel = default;
	public UnityEvent<string> OnEventRaised = new UnityEvent<string>();

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
		if (OnEventRaised != null)
			OnEventRaised.Invoke(value);
	}

	public void SetChannel(StringEventChannelSO channel)
	{
		OnDisable();
		_channel = channel;
		OnEnable();
	}

	
}
