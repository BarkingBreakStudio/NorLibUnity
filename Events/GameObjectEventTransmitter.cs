using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectEventTransmitter : MonoBehaviour
{
    [SerializeField] private GameObjectEventChannelSO channel = default;
    [SerializeField] private GameObject defaultObject = default;

    [ContextMenu("Transmit Event")]
    public void TransmitEvent()
    {
        channel.RaiseEvent(defaultObject);
    }

    public void TransmitEvent(GameObject gameObject)
    {
        channel.RaiseEvent(gameObject);
    }
}
