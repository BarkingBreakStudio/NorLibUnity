using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "NorLib/Audio/Audio Request Channel")]
public class AudioCueEventChannelSO : BaseEventChannelSO<AudioCueEventChannelSO.AudioCueReqest>
{

    [System.Serializable]
    public struct AudioCueReqest
    {
        public AudioClip clip;
    }
}


