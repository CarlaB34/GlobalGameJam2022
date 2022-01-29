using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float multForceBullet = 1;
    public static float degats = 1;

    [SerializeField]
    private bool isLazer;

    public void InitBullet(Vector3 dir)
    {
        Rigidbody rigidBodyBullet = GetComponent<Rigidbody>();

        rigidBodyBullet.AddForce(dir * multForceBullet);

        if(isLazer)
        {
            degats = AliceVise.degats;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet Touch : " + collision.collider.gameObject.name, collision.collider.gameObject);

        // Destruction de la bullet
        GameObject.Destroy(gameObject);
    }
}
