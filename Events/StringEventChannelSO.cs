using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "NorLib/Events/String Event Channel")]
public class StringEventChannelSO : EventChannelBaseSO
{
	public event UnityAction<string> OnEventRaised = delegate { };
	public void RaiseEvent(string value)
	{
		OnEventRaised.Invoke(value);
	}

	public void AddListener(UnityAction<string> action)
    {
		OnEventRaised += action;
	}

	public void RemoveListener(UnityAction<string> action)
	{
		OnEventRaised -= action;
	}
}
