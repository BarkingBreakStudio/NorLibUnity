using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInitializer : MonoBehaviour
{
    public SceneInitializerSO SceneInitSettings;

    void Awake()
    {
        if (SceneInitSettings != null && !SceneManagerEx.IsSceneLoaded(SceneInitSettings.PersistentScene))
        {
            SceneManager.LoadScene(SceneInitSettings.PersistentScene,LoadSceneMode.Additive);
        }
    }
}
