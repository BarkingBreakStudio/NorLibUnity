using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public SceneInitializerSO SceneInitSettings;

    public SceneLoaderSO SceneLoaderRequestChannel;
    private SceneLoaderEventListener SceneLoaderListerner;

    public Animator CrossFadeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        var slel = gameObject.AddComponent<SceneLoaderEventListener>();
        slel.OnEventRaised.AddListener(onLoaderReqest);
        slel.SetChannel(SceneLoaderRequestChannel);
    }

    private void onLoaderReqest(SceneLoaderSO.SceneLoaderReqest request)
    {
        switch (request.reqType)
        {
            case SceneLoaderSO.ReqType.loadScene:
                StartCoroutine(LoadScene(request.scene));
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator LoadScene(string sceneName)
    {
        Physics.autoSimulation = false;
        List<string> ScenesToDesroy = new List<string>();

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene curScene = SceneManager.GetSceneAt(i);
            if(curScene.path != SceneInitSettings.PersistentScene)
            {
                ScenesToDesroy.Add(curScene.name);
            }
        }

        yield return StartCrossFade();

        foreach (var scene in ScenesToDesroy)
        {
            yield return SceneManager.UnloadSceneAsync(scene);
        }

        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByPath(sceneName));

        ContinueCrossFade();
        Physics.autoSimulation = true;
    }

    public IEnumerator StartCrossFade()
    {
        if(CrossFadeAnimator != null)
        {
            CrossFadeAnimator.SetTrigger("StartCrossFade");
            yield return new WaitForSeconds(1);
        }
    }

    public void ContinueCrossFade()
    {
        if (CrossFadeAnimator != null)
        {
            CrossFadeAnimator.SetTrigger("ContinueCrossFade");
        }
    }


}
