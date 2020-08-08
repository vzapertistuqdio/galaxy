using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bot : MonoBehaviour
{
    private Timer timeScript;
    private Score scoreScript;
    private AliveCounter aliveCount;


    [SerializeField] private Text destroyText;
    [SerializeField] private ParticleSystem[] destroyParticle;
    [SerializeField] private int botPower;

    private string name;
    private void Start()
    {
        timeScript = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<Timer>();
        scoreScript = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<Score>();
        aliveCount = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<AliveCounter>();
        name = gameObject.name;
        destroyText.enabled = false;
    }


    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            destroyText.enabled = true;
            destroyText.text = name + " WAS DESTROYED";
            aliveCount.DecrementPlayerCount();
            scoreScript.AddScore(botPower);
            timeScript.SetMaxTime();
            for (int i=0;i<destroyParticle.Length;i++)
            {
                destroyParticle[i].Play();
            }
            StartCoroutine(DestroyAfterTime());
        }
    }

    private IEnumerator DestroyAfterTime()
    {
       
        yield return new WaitForSeconds(0.5f);
        destroyText.enabled = false;
        Destroy(this.gameObject);
    }
}
