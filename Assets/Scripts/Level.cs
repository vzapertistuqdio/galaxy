using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Slider lvlSlider;
    [SerializeField] private Text lvlText;

    private int level;

    private int scoreCountForFirstLevel = 5;

    public int MustCatchToLvlUp { get { return mustCatchToLvlUp; } private set {; } }
    private int mustCatchToLvlUp;

    private Score scoreScript;


    private void Start()
    {
        scoreScript = GetComponent<Score>();
        level = 1;
        mustCatchToLvlUp=level* scoreCountForFirstLevel;
        lvlSlider.value = 0;
    }

   
    private void Update()
    {    
        if(mustCatchToLvlUp<=scoreScript.GetScore())
        {
            lvlSlider.value = 0;
            level++;
            mustCatchToLvlUp = level * scoreCountForFirstLevel;
            scoreScript.SetScore(0);
        }
        ;
        int score = scoreScript.GetScore(); 
        lvlSlider.value =(float)score/(float)mustCatchToLvlUp;      
        lvlText.text = "Lvl " + level;
    }

    public int GetLevel()
    {
        return level;
    }
}
