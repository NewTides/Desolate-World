using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private RaycastHit vision;
    public float rayLength;
    private bool isGrabbed;
    private Rigidbody grabbedObject;
    
    // Start is called before the first frame update
    void Start()
    {
        rayLength = 6.0f;
        isGrabbed = false;

    }

    // Update is called once per frame
    void Update()
    {
        Dubug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red, 0.5f);
        
        
    }
}
