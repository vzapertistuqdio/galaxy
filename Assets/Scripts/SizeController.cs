using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour
{
    [SerializeField] private ParticleSystem sunParticle;
    private Score levelScript;
    private void Start()
    {
      
        levelScript =GameObject.FindGameObjectWithTag("ScoreController").GetComponent<Score>();
    }

    
    private void Update()
    {
        sunParticle.startSize = 0.5f + levelScript.GetScore() / 10;
        transform.localScale = new Vector3(0.5f + levelScript.GetScore() / 10, 0.5f + levelScript.GetScore() / 10, 0.5f + levelScript.GetScore() / 10);
    }
}
