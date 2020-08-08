using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigibody;
  
    public bool isConnected;

    [SerializeField] private float speed;
    [SerializeField] private float useRopeRadius;

    [SerializeField] private LineRenderer rope;
    [SerializeField] private LineRenderer potentialRope;

    [SerializeField] private LayerMask wall;

    private Collider connectedCollider;
    
    private void Start()
    {
        isConnected = false;
        playerRigibody = GetComponent<Rigidbody>();
        potentialRope.enabled = false;
        rope.enabled = false;   
    }

    private void FixedUpdate()
    {
        FindWallsAround();
    }
    private void Update()
    {
        rope.SetPosition(0, transform.position);
        if (Input.GetMouseButton(0) == false)
        {
            DrawPotentialRope();
        }

        if (Input.GetMouseButtonDown(0) && isConnected==false)
        {
            Collider nearestWall = CheckNearestWall(FindWallsAround());
            connectedCollider = nearestWall;
            EnableHook(nearestWall);
            potentialRope.enabled = false;
           
        }
        if(Input.GetMouseButtonUp(0))
        {
            DisableHook(connectedCollider);
        }
       
        
        
    }

    private Collider[] FindWallsAround()
    {
       Collider[] walls=Physics.OverlapSphere(transform.position,useRopeRadius,wall);
       
        return walls;
    }

    private Collider CheckNearestWall(Collider[] walls)
    {
        Collider nearestWall = walls[0];
        float nearestDistance = DistanceToWall(nearestWall);
        if (walls.Length > 1)
        {
            for (int i = 1; i < walls.Length; i++)
            {
                float distance = DistanceToWall(walls[i]);
               
                if (distance<nearestDistance)
                {
                    nearestDistance = distance;
                    nearestWall = walls[i];
                }
            }
        }
        return nearestWall;
    }

    private float DistanceToWall(Collider wall)
    {
        float distance;
        distance = Mathf.Sqrt(Mathf.Pow((transform.position.x-wall.transform.position.x),2)+Mathf.Pow((transform.position.y-wall.transform.position.y),2) + Mathf.Pow((transform.position.z - wall.transform.position.z), 2));
        return distance;
    }

    private void EnableHook(Collider nearestWall)
    {
        if(nearestWall.gameObject.GetComponent<HingeJoint>()!=null)
        {
            if (isConnected == false)
            {
                nearestWall.gameObject.GetComponent<HingeJoint>().connectedBody = playerRigibody;
            }
            rope.SetPosition(1, nearestWall.transform.position);
            rope.enabled = true;
            isConnected = true;
        }    
    }

    private void DisableHook(Collider nearestWall)
    {
        nearestWall.gameObject.GetComponent<HingeJoint>().connectedBody = null;
        rope.enabled = false;
        isConnected = false;
    }
    
    private void DrawPotentialRope()
    {
        potentialRope.enabled = true;
        potentialRope.SetPosition(0, transform.position);
        Collider nearestWall = CheckNearestWall(FindWallsAround());
        potentialRope.SetPosition(1, nearestWall.transform.position);
    }
}
