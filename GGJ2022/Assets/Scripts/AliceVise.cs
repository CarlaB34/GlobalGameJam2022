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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ennemy = GameObject.FindWithTag("Ennemy");
        Vector3 targetPostition = new Vector3(ennemy.transform.position.x, this.transform.position.y, ennemy.transform.position.z);

        jauge.value += Time.deltaTime;
        transform.LookAt(targetPostition);

        degats = jauge.value;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CreateAttack(newBullet);

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
