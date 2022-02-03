using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Variable membre rigidbody du player
    Rigidbody rigidBodyPlayer;

    public float speed = 1;

    public Transform view;

    [SerializeField]
    private Animator rabbitAnimator;

   

    // Start is called before the first frame update
    void Start()
    {
        // On intialise notre variable en recupérant le component
        rigidBodyPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vecteur pour la direction du mouvement
        Vector3 moveDir = Vector3.zero;
        // On recupère les inputs droite/gauche et on applique sur l'axe Z
        if (Input.GetKey(KeyCode.D))
        {
            moveDir.z = 1;

            rabbitAnimator.SetBool("IsWalking", true);



        }

        if (Input.GetKey(KeyCode.Q))
        {
            moveDir.z = -1;
            rabbitAnimator.SetBool("IsWalking", true);
        }

        // On recupère les inputs haut/bas et on applique sur l'axe X
        if (Input.GetKey(KeyCode.S))
        {
            moveDir.x = 1;
            rabbitAnimator.SetBool("IsWalking", true);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            moveDir.x = -1;
            rabbitAnimator.SetBool("IsWalking", true);
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            moveDir.x = -1;
            rabbitAnimator.SetBool("IsWalking", false);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            moveDir.x = -1;
            rabbitAnimator.SetBool("IsWalking", false);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            moveDir.x = -1;
            rabbitAnimator.SetBool("IsWalking", false);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            moveDir.x = -1;
            rabbitAnimator.SetBool("IsWalking", false);
        }






        // Permet de forcer la magnitude du vecteur à 1
        moveDir.Normalize();

        // On applique la velocité calculé sur le rigidbody
        rigidBodyPlayer.velocity = moveDir * speed;

        if (moveDir != Vector3.zero)
        {
            view.rotation = Quaternion.LookRotation(moveDir);
        }
    }
}
