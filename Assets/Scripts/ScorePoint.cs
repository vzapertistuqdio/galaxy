using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    private Score scoreScript;
    private Timer timeScript;
    private ScoreRandomGeneration randomGeneration;
    [SerializeField] private int timeCost;

    [SerializeField] private ParticleSystem[] explosiveParticles;
    private void Start()
    {
        scoreScript = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<Score>();
        timeScript = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<Timer>();
        randomGeneration= GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreRandomGeneration>();
    }

   
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
     
        if (other.GetComponent<PlayerController>() != null)
        {
            timeScript.AddTime(timeCost);
            scoreScript.IncremenScore();
            for(int i=0;i<explosiveParticles.Length;i++)
            {
                explosiveParticles[i].Play();
            }
            randomGeneration.CurrentObjCount--;
            StartCoroutine(DestroyAfterTime(0.2f));
        }
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
