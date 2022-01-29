using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AliceVise : MonoBehaviour
{
    [SerializeField]
    private GameObject ennemy;

    [SerializeField]
    private Slider jauge;

    public static float degats;

    [SerializeField]
    private Transform originAttack;

    [SerializeField]
    private GameObject newBullet;

    [SerializeField]
    private float timerBeforeResetValueLazer;
    [SerializeField]
    private bool hasLaunchedLazer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ennemy = GameObject.FindWithTag("Ennemy");

        if(ennemy != null)
        {
            Vector3 targetPostition = new Vector3(ennemy.transform.position.x, this.transform.position.y, ennemy.transform.position.z);
            transform.LookAt(targetPostition);
        }
 

        jauge.value += Time.deltaTime;
       

        degats = jauge.value;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CreateAttack(newBullet);
            hasLaunchedLazer = true;
        }

        if(hasLaunchedLazer)
        {
            timerBeforeResetValueLazer -= Time.deltaTime;
        }

        if(timerBeforeResetValueLazer <= 0)
        {
            jauge.value = 0;
            hasLaunchedLazer = false;
            timerBeforeResetValueLazer = 1;
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
}
