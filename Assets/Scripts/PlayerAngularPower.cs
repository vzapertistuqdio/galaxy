using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAngularPower : MonoBehaviour
{
    private float lastZPos;
   [SerializeField] private float force;

    private Rigidbody playerRigibody;
    private PlayerController playerController;
   
    private void Start()
    {
        lastZPos = transform.position.z;
        playerRigibody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }

    
    private void Update()
    {
        playerController = GetComponent<PlayerController>();
        if (playerController.isConnected)
        {
            AddForce();
            
        }
    }

    private void AddForce()
    {
        if(transform.position.z>lastZPos) //right
        {
            playerRigibody.AddForce(new Vector3(0, 0, force), ForceMode.Impulse);
        }
        
        if(transform.position.z < lastZPos ) //left
        {
            playerRigibody.AddForce(new Vector3(0, 0, -force), ForceMode.Impulse);           
        }
        lastZPos = transform.position.z;
    }

}
