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
    private GameObject AliceVisual;

    [SerializeField]
    private GameObject[] HeartsUi;

    private float timeBeforeTheScene = 3;
    private bool isDead;

    [SerializeField]
    private GameObject tr2;

    [SerializeField]
    private string nameOfNextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0 && timeBeforeTheScene >= 2.95)
        {
            Death();
        }
        if(isDead)
        {
            timeBeforeTheScene -= Time.deltaTime;
        }

        if(timeBeforeTheScene <= 1)
        {
            tr2.SetActive(true);
        }
        if (timeBeforeTheScene <= 0)
        {
            SceneManager.LoadScene(nameOfNextScene);
        }

        if(life < 6)
        {
            HeartsUi[life].SetActive(false);
        }
        
    }

    void Death()
    {
        WinCondition.isWinning = false;
        isDead = true;
        Instantiate(particleDeath, this.transform.position, Quaternion.identity);
        GameObject.Destroy(AliceVisual);
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
