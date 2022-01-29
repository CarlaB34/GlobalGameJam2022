using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnnemyScript : MonoBehaviour
{
    private NavMeshAgent navMesh;

    private GameObject Alice;

    
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        Alice = GameObject.FindWithTag("Alice");
        navMesh.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(Alice.transform.position);

      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Field")
        {
            navMesh.speed = navMesh.speed / 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Field")
        {
            navMesh.speed = speed;
        }
    }

}
