using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time;
    private const float MAX_TIME = 30;
    [SerializeField] private Slider timeSlider;
    private void Start()
    {
        time = MAX_TIME/2;
    }

    
    private void Update()
    {
        timeSlider.value = time / MAX_TIME;
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time -= Time.deltaTime;
            Time.timeScale = 0;
        }
    }

    public void AddTime(float amount)
    {
        time = time + amount;
        if (time >= MAX_TIME)
            time = MAX_TIME;
    }

    public void SetMaxTime()
    {
        time = MAX_TIME;
    }
}
