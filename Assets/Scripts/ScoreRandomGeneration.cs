using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRandomGeneration : MonoBehaviour
{
    [SerializeField] private GameObject scoreObjectPrefab;
    private Level levelScript;

    private int maxObjectCount;

    public int CurrentObjCount { get { return currentObjCount; } set { currentObjCount = value; } }
    private int currentObjCount;

    private const int EXTRA_SCORE = 2;
    private void Start()
    {
        levelScript = GetComponent<Level>();
        maxObjectCount = 10;
       GenerateObjects();
        CurrentObjCount = maxObjectCount;
    }

    
    private void Update()
    {
        //maxObjectCount = levelScript.MustCatchToLvlUp;
        if (currentObjCount<7)
        {
            GenerateObjects();
        }
        
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 randomPos;
        randomPos = new Vector3(-4f, Random.Range(-32,40), Random.Range(-24f, 44f));
        return randomPos;
    }
    private void GenerateObjects()
    {
     
        for (int i = 0; i < maxObjectCount; i++)
        {
            GameObject scoreObject;
            scoreObject = Instantiate(scoreObjectPrefab);
            scoreObject.transform.position = GenerateRandomPosition();
        }
        CurrentObjCount += maxObjectCount;
    }
}
