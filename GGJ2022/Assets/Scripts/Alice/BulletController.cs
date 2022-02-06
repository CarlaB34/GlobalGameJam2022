using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float multForceBullet = 1;
    public static float degats = 1;

    [SerializeField]
    private bool isLazer;
    [SerializeField]
    private GameObject particleHit;

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
        Instantiate(particleHit, this.transform.position, Quaternion.identity);
        // Destruction de la bullet
        GameObject.Destroy(gameObject);
    }
}
