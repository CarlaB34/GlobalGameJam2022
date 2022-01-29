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

   

   

    // Start is called before the first frame update
    void Start()
    {
        // On intialise notre variable en recup�rant le component
        rigidBodyPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vecteur pour la direction du mouvement
        Vector3 moveDir = Vector3.zero;
        // On recup�re les inputs droite/gauche et on applique sur l'axe Z
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDir.z = 1;

       

         

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDir.z = -1;
   
        }

        // On recup�re les inputs haut/bas et on applique sur l'axe X
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDir.x = 1;
          
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDir.x = -1;
          
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            moveDir.x = -1;
           
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moveDir.x = -1;
           
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            moveDir.x = -1;
           
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveDir.x = -1;
         
        }






        // Permet de forcer la magnitude du vecteur � 1
        moveDir.Normalize();

        // On applique la velocit� calcul� sur le rigidbody
        rigidBodyPlayer.velocity = moveDir * speed;

        if (moveDir != Vector3.zero)
        {
            view.rotation = Quaternion.LookRotation(moveDir);
        }
    }
}
