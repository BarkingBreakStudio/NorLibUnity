using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DbgConsole : MonoBehaviour
{
    public void DebugLog(object msg)
    {
        GameObject go = msg as GameObject;
        if (go != null)
        {
            Debug.Log("GameObject: " + go.name);
        }
        else
        {
            Debug.Log(msg);
        }
    }

    public void DebugLog(string msg)
    {
        Debug.Log(msg);
    }
}
