using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectEventListener : MonoBehaviour
{
	[SerializeField] private GameObjectEventChannelSO channel = default;
	public UnityEvent<GameObject> OnEventRaised = new UnityEvent<GameObject>();

	protected void OnEnable()
	{
		channel?.AddListener(Respond);
	}

	protected void OnDisable()
	{
		channel?.RemoveListener(Respond);
	}

	protected virtual void Respond(GameObject value)
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke(value);
	}

	public void SetChannel(GameObjectEventChannelSO channel)
	{
		OnDisable();
		this.channel = channel;
		OnEnable();
	}

}
