using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicManager : MonoBehaviour
{
    public int MusicPhase = 0;
    private FMODUnity.StudioEventEmitter MusicEmitter;

    // Start is called before the first frame update
    void Start()
    {
        MusicEmitter = GetComponent<FMODUnity.StudioEventEmitter>(); 
    }

    // Update is called once per frame
    void Update()
    {
        MusicEmitter.SetParameter("Phase", MusicPhase);
        if (WinCondition.numberOfEnnemiesToWin <= 50 && WinCondition.numberOfEnnemiesToWin > 10)
        {
            MusicPhase = 1;
        }
        if (WinCondition.numberOfEnnemiesToWin <= 20)
        {
            MusicPhase = 2;
        }
    }
}
