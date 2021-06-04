using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Snap : MonoBehaviour
{

    public SnapSO SnapSettings;
    SnapSO old_SnapSettings;
    static SnapSO last_SnapSettings;

    [SerializeField]
    Vector3 gridSize;
    Vector3 old_gridSize;
    [SerializeField]
    bool SnapRelativeToParent = true;
    bool old_SnapRelativeToParent = true;
    [SerializeField]
    bool DeactivateInPlayMode = true;
    bool old_DeactivateInPlayMode = true;




    private void OnDrawGizmos()
    {
        if (Application.isPlaying && DeactivateInPlayMode)
            return;

#if UNITY_EDITOR
        if (!Application.isPlaying && SnapSettings == null)
        {
            if (last_SnapSettings == null)
            {
                string[] guids = AssetDatabase.FindAssets("t:SnapSO");
                if (guids.Length > 0)
                {
                    string path = AssetDatabase.GUIDToAssetPath(guids[0]);
                    SnapSettings = AssetDatabase.LoadAssetAtPath<SnapSO>(path);
                    last_SnapSettings = SnapSettings;
                    old_SnapSettings = SnapSettings;
                }
                else
                {
                    SnapSettings = last_SnapSettings;
                    old_SnapSettings = SnapSettings;
                }
            }
        }
#endif

        if(SnapSettings != null)
        {
            GridSize = SnapSettings.GridSize;
            old_gridSize = GridSize;
            SnapRelativeToParent = SnapSettings.SnapRelativeToParent;
            old_SnapRelativeToParent = SnapRelativeToParent;
            DeactivateInPlayMode = SnapSettings.DeactivateInPlayMode;
            old_DeactivateInPlayMode = DeactivateInPlayMode;
        }
        
        SnapToGrid();
    }

    private void OnValidate()
    {
        if(old_gridSize != GridSize)
        {
            if (SnapSettings != null)
            {
                SnapSettings.GridSize = GridSize;
                old_gridSize = GridSize;
            }
        }
        if (old_SnapRelativeToParent != SnapRelativeToParent)
        {
            if(SnapSettings != null)
            {
                SnapSettings.SnapRelativeToParent = SnapRelativeToParent;
                old_SnapRelativeToParent = SnapRelativeToParent;
            }
        }
        if (old_DeactivateInPlayMode != DeactivateInPlayMode)
        {
            if (SnapSettings != null)
            {
                SnapSettings.DeactivateInPlayMode = DeactivateInPlayMode;
                old_DeactivateInPlayMode = DeactivateInPlayMode;
            }
        }
    }

    void SnapToGrid()
    {
        Vector3 pos = SnapRelativeToParent ? transform.localPosition : transform.position;
        Vector3 grid = GridSize;
        Vector3 newPosition = Vector3.Scale(grid , new Vector3(Mathf.Round(pos.x / grid.x), Mathf.Round(pos.y / grid.y), Mathf.Round(pos.z / grid.z)));
        if (SnapRelativeToParent)
            transform.localPosition = newPosition;
        else
            transform.position = newPosition;

        gridSize = GridSize;
    }


    public Vector3 GridSize
    {
        get
        {
            float min = 0.00001f;
            return Vector3.Max(gridSize, new Vector3(min, min, min));

        }
        set
        {
            if (value.x > 0.00001 && value.y > 0.00001 && value.z > 0.00001)
            {
                gridSize = value;
            }
        }
    }


}

