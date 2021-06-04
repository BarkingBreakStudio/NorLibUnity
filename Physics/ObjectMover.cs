using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{

    public Vector3 MoveDirection;
    public float MoveSpeed = 1f;
    //public bool relativeTo

    public Vector3 RotateDirection;
    public float RotateSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = transform.TransformDirection(MoveDirection);

        var rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.velocity = v3 * MoveSpeed;
        }
        else
        {
            transform.Translate(MoveDirection * MoveSpeed * Time.deltaTime);
            transform.Rotate(RotateDirection * RotateSpeed * Time.deltaTime);
        }
    }
}
