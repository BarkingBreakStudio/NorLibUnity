using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringEventTransmitter : MonoBehaviour
{
    [SerializeField] private StringEventChannelSO _channel = default;

    [ContextMenu("Do Something")]
    public void DoSomething()
    {
        _channel.RaiseEvent("test");
    }
}
