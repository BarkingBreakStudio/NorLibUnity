using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
[CreateAssetMenu(menuName = "NorLib/SceneMngmt/Scene Init Settings")]
public class SceneInitializerSO : ScriptableObject
{ 
      [SceneNamePicker]
      public string PersistentScene;


   
}
