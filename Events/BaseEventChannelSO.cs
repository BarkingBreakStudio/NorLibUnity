using UnityEngine;
using UnityEngine.Events;

public class BaseEventChannelSO<T> : ScriptableObject
{
	[TextArea] public string description;

	public event UnityAction<T> OnEventRaised = delegate { };
	public void RaiseEvent(T value)
	{
		OnEventRaised.Invoke(value);
	}

	public void AddListener(UnityAction<T> action)
	{
		OnEventRaised += action;
	}

	public void RemoveListener(UnityAction<T> action)
	{
		OnEventRaised -= action;
	}

}
