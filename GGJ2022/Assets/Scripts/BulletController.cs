using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float multForceBullet = 1;
    public static int degats = 1;
    public void InitBullet(Vector3 dir)
    {
        Rigidbody rigidBodyBullet = GetComponent<Rigidbody>();

        rigidBodyBullet.AddForce(dir * multForceBullet);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet Touch : " + collision.collider.gameObject.name, collision.collider.gameObject);

        // Destruction de la bullet
        GameObject.Destroy(gameObject);
    }
}
