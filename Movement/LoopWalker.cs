using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopWalker : WaypointWalker
{

    public string PathId; 

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        WalkTo(PathId, PathFinished);       
    }


    void PathFinished()
    {
        WalkTo(PathId, PathFinished);
    }
}
