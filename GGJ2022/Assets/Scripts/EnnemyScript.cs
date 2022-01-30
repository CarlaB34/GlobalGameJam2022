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
    private Transform originAttack;
    
    [SerializeField]
    private float speed;

    [SerializeField]
    private float timeToInstantiateBullet;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float maxLife;
    private float life;

    [SerializeField]
    private float distanceToStop;

    [SerializeField]
    private bool isDistanceEnnemy;
    [SerializeField]
    private GameObject contactAttack;

    [SerializeField]
    private GameObject particleHitLazer;

    [SerializeField]
    private GameObject slownessParticle;

    private bool isOnSlowZone;


    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
        navMesh = GetComponent<NavMeshAgent>();
        Alice = GameObject.FindWithTag("Alice");
        navMesh.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(Alice.transform.position);
        timeToInstantiateBullet -= Time.deltaTime;

        if(timeToInstantiateBullet <= 0)
        {
            CreateAttack(bullet);
            timeToInstantiateBullet = 5;
        }

        if(life <= 0)
        {
            Death();
        }

        double distancePlayer = (double)Vector3.Distance(this.Alice.transform.position, this.transform.position);

        if (distancePlayer < distanceToStop)
        {
            navMesh.speed = 0;

            if(!isDistanceEnnemy)
            {
                contactAttack.SetActive(true);
            }

        }

        if (distancePlayer > distanceToStop + 1 && !isOnSlowZone)
        {
            navMesh.speed = speed;
            if (!isDistanceEnnemy)
            {
                contactAttack.SetActive(false);
            }
        }

    }

   
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Field")
        {
            isOnSlowZone = true;
            slownessParticle.SetActive(true);
            navMesh.speed = speed / 2;
        }

        if (other.gameObject.tag == "Lazer")
        {
            Instantiate(particleHitLazer, this.transform.position, Quaternion.identity);
            life = life - AliceVise.degats;
            //Debug.Log(life);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Field")
        {
            isOnSlowZone = false;
            slownessParticle.SetActive(false);
            navMesh.speed = speed;
        }
    }

    private void CreateAttack(GameObject attack)
    {
        if (attack != null)
        {
            GameObject newBullet = Instantiate(attack);
            newBullet.transform.position = originAttack.position;

            BulletController bulletController = newBullet.GetComponent<BulletController>();
            bulletController.InitBullet(originAttack.forward);
        }
    }

    private void Death()
    {
        WinCondition.numberOfEnnemiesToWin -= 1;
        GameObject.Destroy(gameObject);
    }

}
