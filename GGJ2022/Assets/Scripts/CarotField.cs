using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarotField : MonoBehaviour
{
    [SerializeField]
    private GameObject field;

    [SerializeField]
    private GameObject push;

    public float timeToDoAttack;

    public Animator RabbitAnimator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToDoAttack -= Time.deltaTime;

        if(timeToDoAttack <= 0)
        {
            push.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RabbitAnimator.SetBool("HasField", true);

    
            Instantiate(field, this.transform.position, Quaternion.identity);
      
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
          
            RabbitAnimator.SetBool("HasField", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RabbitAnimator.SetBool("IsToupie", true);
            timeToDoAttack = 0.25f;
            push.SetActive(true);

        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            RabbitAnimator.SetBool("IsToupie", false);
           

        }
    }
}
