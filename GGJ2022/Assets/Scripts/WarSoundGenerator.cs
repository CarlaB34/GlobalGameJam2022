using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarSoundGenerator : MonoBehaviour
{
    public int BattlefieldNumber;
    public int MaxElementInBattlefield; 
    public float MinDistance; 
    public float MaxDistance;
    public float MinTime;
    public float MaxTime; 

    // Start is called before the first frame update
    void Start()
    {
        while(BattlefieldNumber > 0)
        {
            float distance = Random.Range(MinDistance, MaxDistance);
            BattlefieldSoundGenerator b = gameObject.AddComponent<BattlefieldSoundGenerator>();
            b.Init(Random.insideUnitSphere * distance,BattlefieldNumber,Random.Range(0,MaxElementInBattlefield),MinDistance,MaxDistance);
            BattlefieldNumber--; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}