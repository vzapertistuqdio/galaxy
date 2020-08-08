using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AliveCounter : MonoBehaviour
{
    [SerializeField] private Animator textAnimator;
    [SerializeField] private Text aliveText;
    private int alivePlayers;
    private void Start()
    {
        alivePlayers = 3;
    }

   
    private void Update()
    {
        aliveText.text = "Alive " + alivePlayers + "/3";
    }
    public void DecrementPlayerCount()
    {
        alivePlayers--;
        textAnimator.SetBool("textScale", true);
        StartCoroutine(StopAnimAfterTime());
    }
    private IEnumerator StopAnimAfterTime()
    {
        yield return new WaitForSeconds(0.1f);
        textAnimator.SetBool("textScale", false);
    }
}
