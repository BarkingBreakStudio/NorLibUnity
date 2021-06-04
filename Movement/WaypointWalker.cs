using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaypointWalker : MonoBehaviour
{
    public Transform currentTargetPosition = null;
    
    public float MoveSpeed { get { return _movespeed; } set { _movespeed = value; } }
    [SerializeField]
    private float _movespeed = 3f;

    private Queue<Transform> moveTargets = new Queue<Transform>();

    private UnityAction callback;

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected void Update()
    {
        if (currentTargetPosition != null)
        {
            float maxDistance = Time.deltaTime * MoveSpeed;
            Vector3 oldPosition = transform.position;
            transform.position = (Vector3.MoveTowards(transform.position, currentTargetPosition.position, maxDistance));
            Vector3 newPosition = transform.position;
            if ((newPosition - oldPosition).magnitude < 0.5 * maxDistance)
            {
                currentTargetPosition = null;
                if (moveTargets.Count > 0)
                {
                    currentTargetPosition = moveTargets.Dequeue();
                }
                else
                {
                    callback?.Invoke();
                }
            }
        }
    }


    public void WalkTo(string pathId, UnityAction callback = null)
    {
        this.callback = callback;
        var wps = GetComponent<Waypoints>();
        foreach (var wp in wps.wayPoints)
        {
            if (wp.Id == pathId)
            {
                for (int i = 0; i < wp.wPoints.Length; i++)
                {
                    moveTargets.Enqueue(wp.wPoints[i]);
                }
            }
        }

        if (moveTargets.Count > 0)
        {
            currentTargetPosition = moveTargets.Dequeue();
        }
        else
        {
            callback?.Invoke();
        }
    }
}
