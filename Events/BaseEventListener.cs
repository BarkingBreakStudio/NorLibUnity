using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseEventListener<T,U> : MonoBehaviour where T : BaseEventChannelSO<U>
{
	[SerializeField] private T _channel = default;
	public UnityEvent<U> OnEventRaised = new UnityEvent<U>();

	protected void OnEnable()
	{
		_channel?.AddListener(Respond);
	}

	protected void OnDisable()
	{
		_channel?.RemoveListener(Respond);

	}

	protected virtual void Respond(U value)
	{
		OnEventRaised.Invoke(value);
	}

	public void SetChannel(T channel)
	{
		if (enabled)
		{
			OnDisable();
			_channel = channel;
			OnEnable();
		}
		else
        {
			_channel = channel;
		}
	}


	public static V AddComponent<V>(GameObject gm, T channel, UnityAction<U> action) where V : BaseEventListener<T, U>
	{
		V listener  = gm.AddComponent<V>();
		listener.OnEventRaised.AddListener(action);
		listener.SetChannel(channel);
		return listener;
	}

}
