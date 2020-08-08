using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Transform camTransform;
    private Vector3 offset;

    [SerializeField] private GameObject target;
    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

   
    private void Update()
    {
        transform.position = target.transform.position + offset;
    }
}
