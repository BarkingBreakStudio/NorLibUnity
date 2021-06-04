using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [Serializable]
    public class WayPointList
    {
        public string Id;
        public Transform[] wPoints;
    }

    public WayPointList[] wayPoints;


}
