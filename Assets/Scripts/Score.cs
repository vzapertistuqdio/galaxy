using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text powerText;
    [SerializeField] private Animator textAnimator;
    private int score;

    private void Update()
    {
        powerText.text = "Power " + score;
    }
    public int GetScore()
    {
        return score;
    }
    public void SetScore(int value)
    {
        score = value;
    }
    public void AddScore(int count)
    {
        score = score + count;
    }
    public void IncremenScore()
    {
        score = score + 5;
        textAnimator.SetBool("textScale",true);
        StartCoroutine(StopAnimAfterTime());
    }
    private IEnumerator StopAnimAfterTime()
    {
        yield return new WaitForSeconds(0.1f);
        textAnimator.SetBool("textScale", false);
    }
}
