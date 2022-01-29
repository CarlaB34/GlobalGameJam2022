using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AliceLife : MonoBehaviour
{

    [SerializeField]
    private int life;
    [SerializeField]
    private float timeOfDeath;

    [SerializeField]
    private GameObject particleDeath;

    [SerializeField]
    private GameObject particleHit;

    [SerializeField]
    private GameObject[] HeartsUi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            Death();
        }

        HeartsUi[life].SetActive(false);
    }

    void Death()
    {
        Instantiate(particleDeath, this.transform.position, Quaternion.identity);
        GameObject.Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Instantiate(particleHit, this.transform.position, Quaternion.identity);
            life = life - 1;
        }
    }
}
