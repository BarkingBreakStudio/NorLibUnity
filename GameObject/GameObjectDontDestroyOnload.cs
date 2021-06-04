using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDontDestroyOnload : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
