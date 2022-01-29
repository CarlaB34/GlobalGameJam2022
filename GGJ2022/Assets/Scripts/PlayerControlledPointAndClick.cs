using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class PlayerControlledPointAndClick : MonoBehaviour
{
    [SerializeField]
    private Camera m_cam;
    [SerializeField]
    private NavMeshAgent m_PlayerNav;
    [SerializeField]
    private GameObject m_TargetDestination;
    [SerializeField]
    private List<GameObject> m_InteractibleObject = new List<GameObject>();
    [SerializeField]
    private GameObject[] m_InteractArraw = { };
    [SerializeField]
    private List<GameObject> m_InteractibleObjectNULL = new List<GameObject>();

    [SerializeField]
    private AudioSource m_Voice1;

    //[SerializeField]
    //private Animator m_PlayerAnimator;

    private void Update()
    {
        ClickMove();

        //si on touche un objet interactif null

        /*if(m_Player.velocity != Vector3.zero)
        {
            m_PlayerAnimator.SetBool("isWalking", true);
        }
        else if (m_Player.velocity == Vector3.zero)
        {
            m_PlayerAnimator.SetBool("isWalking", false);

        }*/
    }

    private void ClickMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray l_Ray = m_cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit l_HitRayPoint;

            //nous fait avance
            if (Physics.Raycast(l_Ray, out l_HitRayPoint))
            {
                m_TargetDestination.transform.position = l_HitRayPoint.point;
                m_PlayerNav.SetDestination(l_HitRayPoint.point);

                
                //si un element de ma liste contient un element que l'on touche de typ gameobject
                if (m_InteractibleObject.Contains(l_HitRayPoint.collider.gameObject))
                {
                    switch (l_HitRayPoint.collider.gameObject.name)
                    {
                        case "PhotoPapa":
                            //m_Voice1.Play();
                            //SceneManager.LoadScene("Noam");
                            Debug.Log("papa");

                            break;

                        case "JournalIntime":
                            Debug.Log("journal");
                            break;

                        case "LivreDechirer":
                            Debug.Log("livre");
                            break;


                    }


                    int l_Index = 0;
                    

                  switch(l_Index)
                   {

                   }

                }

            }
        }



    }


    private void ClickInteractibleObject()
    {

    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    //si on se deplace sur un objet dans le decord
    //    if (collision.gameObject.tag == "InteractibleObject")
    //    {
    //        m_IsMove = false;
    //        m_Player.stoppingDistance = m_InteractibleObject.Count;
    //       // m_Player.speed = 0;
    //        Debug.Log("je collision et je m'arrete : " + m_IsMove);
    //    }

    //    if (collision.gameObject.tag == "Sol")
    //    {
    //        ClickMove();

    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    //si on se deplace sur un objet dans le decord
    //    if (collision.gameObject.tag != "InteractibleObject")
    //    {
    //        m_IsMove = true;
    //    }
    //}
}
