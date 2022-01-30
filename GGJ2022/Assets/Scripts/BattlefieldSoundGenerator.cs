using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//This class create x BattlefieldElement 
public class BattlefieldSoundGenerator : MonoBehaviour
{
    private string[] events = {
        "event:/WarAmbiance/Canon",
        "event:/WarAmbiance/Canon",
        "event:/WarAmbiance/Fire",
        "event:/WarAmbiance/SingleFire",
        "event:/WarAmbiance/SingleFire",
        "event:/WarAmbiance/SingleFire"
    };



    public void Init(Vector3 Location, int Number, float TimeMin, float TimeMax, float Probability = 50.0f)
    {
        while (Number > 0)
        {
            BattlefieldElement b = gameObject.AddComponent<BattlefieldElement>();
            b.Init(events[Random.Range(0, 5)], Location, TimeMin, TimeMax, Probability);
            Number--; 
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }



}
