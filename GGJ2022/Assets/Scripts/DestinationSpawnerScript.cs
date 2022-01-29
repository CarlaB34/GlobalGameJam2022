using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationSpawnerScript : MonoBehaviour
{

    [SerializeField]
    private GameObject Alice;

    [SerializeField]
    private float distanceToDetect;

    [SerializeField]
    private Transform[] spawners;

    [SerializeField]
    private float timerToInstantiate;
    [SerializeField]
    private float originalTimerToInstantiate;

    [SerializeField]
    private GameObject[] ennemies;

    public bool canInstantiate;

    // Start is called before the first frame update
    void Start()
    {
        Alice = GameObject.FindWithTag("Alice");
    }

    // Update is called once per frame
    void Update()
    {
        double distancePlayer = (double)Vector3.Distance(this.Alice.transform.position, this.transform.position);

        if (distancePlayer < distanceToDetect)
        {
            timerToInstantiate -= Time.deltaTime;
           
        }

        if(canInstantiate)
        {
            
            Instantiate((ennemies[Random.Range(0, ennemies.Length - 1)]), (spawners[Random.Range(0, spawners.Length - 1)].transform.position), Quaternion.identity);
            timerToInstantiate = originalTimerToInstantiate;
            canInstantiate = false;
        }
    }
}
