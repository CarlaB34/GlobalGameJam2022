using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlefieldElement : MonoBehaviour
{
    public string EventName;
    public Vector3 Location;
    public float TimeIntervalMin;
    public float TimeIntervalMax;
    [Range(0, 100)]
    public float Probability;

    private float TimeLeft;

    public void Init(string Event, Vector3 Loc, float TimeMin, float TimeMax, float probability)
    {
        EventName = Event;
        Location = Loc;
        TimeIntervalMin = TimeMin;
        TimeIntervalMax = TimeMax;
        Probability = probability;
        Start();
    }

    void Start()
    {
        TimeLeft = Random.Range(TimeIntervalMin, TimeIntervalMax);
    }


    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft <= 0)
        {
            TimeLeft = Random.Range(TimeIntervalMin, TimeIntervalMax);
            if (Random.Range(0.0f, 100.0f) >= Probability)
            {
                FMODUnity.RuntimeManager.PlayOneShot(EventName, Location);
            }
        }
    }
}
