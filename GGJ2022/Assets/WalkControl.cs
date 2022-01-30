using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkControl : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter StepEvent;
    public float SpeedFactor = 1;
    public float TimeInterval = 0.65f;

    private float TimeLeft;
    private bool Stopped; 

    // Start is called before the first frame update
    void Start()
    {
        Stopped = SpeedFactor <= 0.5f;
        if (!Stopped)
        {
            TimeLeft = TimeInterval / SpeedFactor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Stopped = SpeedFactor <= 0.5f;
        if (!Stopped)
        {
            TimeLeft -= Time.deltaTime;
            Debug.Log("Time : " + TimeLeft);
            if (TimeLeft <= 0.0f)
            {

                StepEvent.Play();
                TimeLeft = TimeInterval / SpeedFactor;
            }
        }
    }
}
