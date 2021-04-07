using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.EventSystems;


public class TitanController : MonoBehaviour
{

    public Transform[] points; // array of transforms - different points on the patrol path
    private int destPoint = 0;
    private TitanController _titan;
    private Vector3 _titanVelocity;
    public float speed = 1f;
    public float distance;
    private Vector3 targetPosition;
    
    /*
    public float rayDistance = 6f;
    public Transform rayFrom;    // detect ray from here
    public LayerMask rayCastOn;  // raycast on this layer!
    public enum ChipStates {SCAN, FIRE}
    public ChipStates chipstate = ChipStates.SCAN;
    */

    void Start()
    {
        _titan = GetComponent<TitanController>();
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        // returns if no points have been set up

        targetPosition = points[destPoint].position; // sets the titan's next point to go to
        destPoint = (destPoint + 1) % points.Length; // sets the next point in the array as the destination
        // cycles back to the start of the array after the last point
    }

    void Update()
    {

        Vector3 currentPosition = _titan.transform.position;
        //first, check to see if we're close enough to the target
        distance = Vector3.Distance(currentPosition, targetPosition);
        if (distance > 0.5f)
        {
            Vector3 directionOfTravel = targetPosition - currentPosition;
            //now normalize the direction, since we only want the direction information
            directionOfTravel.Normalize();
            //scale the movement on each axis by the directionOfTravel vector components
            _titan.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World);
        }
        else
        {
            GotoNextPoint();
        }
        /*
        switch (chipstate)
        {
            case ChipStates.SCAN:
                Scan();
                break;
            case ChipStates.FIRE:
                Attack();
                break;
        }
        */
    }
    
   // void OnTriggerEnter(Collider other)
    //{
        // is it a virus?
        //if (other.CompareTag("Player"))
       // {
            // find where on the grid this is
            /* Vector3Int position = grid.WorldToCell(rayFrom.position); 
            tilemap.SetTile(position, null); // set tile at this position as null
            rb.velocity = Vector2.zero; // stop any movement */
           // chipstate = ChipStates.SCAN; // resume scan 
                
       // }
    //}

    /*
    void Scan()
    {
        Vector3 forward = transform.TransformDirection(Vector3.up) * rayDistance;
        RaycastHit hit = Physics.Raycast( rayFrom.position, forward, rayDistance, rayCastOn, QueryTriggerInteraction.UseGlobal);
        if (hit.collider != null)
        {
            Debug.Log($"Hit {hit.collider.name}");
            // draw red if hit
            Debug.DrawRay( rayFrom.position, forward, Color.red);
            //chipstate = ChipStates.CLEAN;
                
        }
        else
        {
            // draws green if no hit
            Debug.DrawRay( rayFrom.position, forward, Color.green);
        }
    }

    void Attack()
    {
            
    }
    */
    
}
