using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PhysTrigger : MonoBehaviour
{

    public UnityEvent EvtTriggerEnter;
    public UnityEvent EvtTriggerLeave;

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
        if (TagFilter.Count == 0 || other.CompareTags(TagFilter))
        {
            EvtTriggerEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (TagFilter.Count == 0 || other.CompareTags(TagFilter))
        {
            EvtTriggerLeave.Invoke();
        }
    }
}