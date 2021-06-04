using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEventTransmitter<T,U> : MonoBehaviour where T : BaseEventChannelSO<U>
{
    [SerializeField] private T channel = default;
    [SerializeField] private U defaultObject = default;

    [Header("Start up")]
    [SerializeField] bool transmitOnStart = false;
    [SerializeField] float startDelay = 0.0f;

    public void TransmitEvent()
    {
        channel.RaiseEvent(defaultObject);
    }

    public void TransmitEvent(U paramObj)
    {
        channel.RaiseEvent(paramObj);
    }

    public void SetChannel(T channel)
    {
        this.channel = channel;
    }

    protected virtual void Start()
    {
        if(transmitOnStart)
        {
            if (startDelay > float.Epsilon)
            {
                StartCoroutine(ExecuteAfterTime(startDelay));
            }
            else
            {
                TransmitEvent();
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        TransmitEvent();
    }
}
