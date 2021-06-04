using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringEventListener : BaseEventListener<BaseEventChannelSO<string>, string>
{
	
	public static StringEventListener AddComponent(GameObject gm, BaseEventChannelSO<string> channel, UnityAction<string> action)
    {
        return BaseEventListener<BaseEventChannelSO<string>, string>.AddComponent<StringEventListener>(gm, channel, action);
    }

}
