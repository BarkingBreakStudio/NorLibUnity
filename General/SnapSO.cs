using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "NorLib/General/SnapSettings")]
public class SnapSO : ScriptableObject
{
    public Vector3 GridSize = Vector3.one;
    public bool SnapRelativeToParent = true;
    public bool DeactivateInPlayMode = true;

}
