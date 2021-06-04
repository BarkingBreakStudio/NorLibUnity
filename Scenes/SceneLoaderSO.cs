using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "NorLib/Scene/Scene Loader Reqest Channel")]
public class SceneLoaderSO : BaseEventChannelSO<SceneLoaderSO.SceneLoaderReqest>
{


    [System.Serializable]
    public enum ReqType
    {
        loadScene,
    }

    [System.Serializable]
    public struct SceneLoaderReqest
    {
        [SceneNamePicker]
        public string scene;
        public ReqType reqType;
    }
}


