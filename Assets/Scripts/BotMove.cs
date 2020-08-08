using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMove : MonoBehaviour
{
    [SerializeField] private GameObject planet;
    [SerializeField] private float speed;

    [SerializeField] private LineRenderer botRope;

    private void Start()
    {
        botRope.enabled = true;
        botRope.SetPosition(1, planet.transform.position);
    }

    private void Update () {
        transform.RotateAround(planet.transform.position, new Vector3(1,0,0), speed * Time.deltaTime);
        botRope.SetPosition(0, transform.position);
    }
}
