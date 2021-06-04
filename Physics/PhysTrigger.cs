using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PhysTrigger : MonoBehaviour
{

    public UnityEvent EvtColliderEnter;
    public UnityEvent<GameObject> EvtColliderEnterGo;
    public UnityEvent EvtColliderLeave;
    public UnityEvent<GameObject> EvtColliderLeaveGo;

    public List<string> TagFilter = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        EnterCollider(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        ExitCollider(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnterCollider(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        ExitCollider(collision.gameObject);
    }

    private void EnterCollider(GameObject other)
    {
        if (TagFilter.Count == 0 || other .CompareTags(TagFilter))
        {
            EvtColliderEnter.Invoke();
            EvtColliderEnterGo.Invoke(other.gameObject);
        }
    }

    private void ExitCollider(GameObject other)
    {
        if (TagFilter.Count == 0 || other.CompareTags(TagFilter))
        {
            EvtColliderLeave.Invoke();
            EvtColliderLeaveGo.Invoke(other.gameObject);
        }
    }
}