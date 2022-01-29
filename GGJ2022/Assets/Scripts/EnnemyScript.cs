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

    }

   
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Lazer")
        {
            life = life - AliceVise.degats;
            Debug.Log(life);
        }
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
        GameObject.Destroy(gameObject);
    }

}
