using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumblerSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject tumblerPrefab;
    [SerializeField]
    GameObject tumblerParent;
    [SerializeField]
    Vector3 startTumblerPosition;
    [SerializeField]
    float gapBetweenTumblers;
    [SerializeField]
    PinManager pinManager;


    private void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnTumblers(GameDifficulty difficulty)
    {
        int numTumblers;

        switch (difficulty)
        {
            case GameDifficulty.EASY:
                numTumblers = 3;
                break;
            case GameDifficulty.NORMAL:
                numTumblers = 4;
                break;
            case GameDifficulty.HARD:
                numTumblers = 5;
                break;
            default:
                numTumblers = 4;
                break;
        }


        // actual tumbler spawning
        for (int i = 0; i < numTumblers; i++)
        {
            Vector3 newTumblerPosition = new Vector3(startTumblerPosition.x + (gapBetweenTumblers * i), startTumblerPosition.y, startTumblerPosition.z);
            Instantiate(tumblerPrefab, newTumblerPosition, Quaternion.identity, tumblerParent.transform);
        }

        pinManager.SetUpPins();
    }
}
