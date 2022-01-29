using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawners;

    [SerializeField]
    private float timerToInstantiate;
    [SerializeField]
    private float originalTimerToInstantiate;

    [SerializeField]
    private GameObject[] ennemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerToInstantiate -= Time.deltaTime;
        if (timerToInstantiate <= 0)
        {

            Instantiate((ennemies[Random.Range(0, ennemies.Length - 1)]), (spawners[Random.Range(0, spawners.Length - 1)].transform.position), Quaternion.identity);
            timerToInstantiate = originalTimerToInstantiate;
           
        }
    }
}
