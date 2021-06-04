using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGo : MonoBehaviour
{
    public float RotateSpeed{ get { return _rotateSpeed; } set { _rotateSpeed = value; } }
    public Vector3 RotateDirection;

    [SerializeField]
    private float _rotateSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotateDirection * RotateSpeed * Time.deltaTime);
    }
}
