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
    }
}
