using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDestroyer : MonoBehaviour
{
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public void DestroyGameObject(GameObject gameObj)
    {
        Destroy(gameObj);
    }
}
