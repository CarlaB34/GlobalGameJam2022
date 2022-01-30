using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AliceIABehaviour : MonoBehaviour
{
    private NavMeshAgent navMesh;

    private GameObject Rabbit;

    [SerializeField]
    private float[] distances;
    [SerializeField]
    private float[] speeds;
    [SerializeField]
    private Animator aliceAnimator;



    public FMODUnity.StudioEventEmitter StepEvent;
    public float SpeedFactor = 1;
    public float TimeInterval = 0.65f;

    private float TimeLeft;
    private bool Stopped;


    // Start is called before the first frame update
    void Start()
    {

        navMesh = GetComponent<NavMeshAgent>();
        Rabbit = GameObject.FindWithTag("Rabbit");



        Stopped = SpeedFactor <= 0.5f;
        if (!Stopped)
        {
            TimeLeft = TimeInterval / SpeedFactor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(Rabbit.transform.position);

        double distancePlayer = (double)Vector3.Distance(this.Rabbit.transform.position, this.transform.position);

        if (distancePlayer < distances[0])
        {
            navMesh.speed = speeds[0];
            aliceAnimator.SetBool("IsWalking", false);
            SpeedFactor = speeds[0];
        }

        if (distancePlayer < distances[1] && distancePlayer >= distances[0])
        {
            navMesh.speed = speeds[1];
            aliceAnimator.SetBool("IsWalking", true);
            SpeedFactor = speeds[1];
        }

        if (distancePlayer < distances[2] && distancePlayer >= distances[1])
        {
            navMesh.speed = speeds[2];
            aliceAnimator.SetBool("IsWalking", true);
            SpeedFactor = speeds[2];
        }


        Stopped = SpeedFactor <= 0.5f;
        if (!Stopped)
        {
            TimeLeft -= Time.deltaTime;
            //Debug.Log("Time : " + TimeLeft);
            if (TimeLeft <= 0.0f)
            {

                StepEvent.Play();
                TimeLeft = TimeInterval / SpeedFactor;
            }
        }


    }
}
