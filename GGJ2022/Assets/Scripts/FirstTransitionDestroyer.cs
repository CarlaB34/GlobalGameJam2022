using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTransitionDestroyer : MonoBehaviour
{
    [SerializeField]
    private float timeBeforeDestroy = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeDestroy -= Time.deltaTime;

        if(timeBeforeDestroy <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
