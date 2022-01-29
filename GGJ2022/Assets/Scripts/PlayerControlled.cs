using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControlled : MonoBehaviour
{
    [SerializeField]
    private Camera m_cam;
    [SerializeField]
    private NavMeshAgent m_Player;
    [SerializeField]
    private GameObject m_TargetDestination;
    [SerializeField]
    private List<GameObject> m_InteractibleObject = new List<GameObject>();
    //[SerializeField]
    //private Animator m_PlayerAnimator;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray l_Ray = m_cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit l_HitRayPoint;

            if (Physics.Raycast(l_Ray, out l_HitRayPoint))
            {
                m_TargetDestination.transform.position = l_HitRayPoint.point;
                m_Player.SetDestination(l_HitRayPoint.point);

            }
            if (m_InteractibleObject.Count <=0 )
            {
               // m_TargetDestination.transform.position = l_HitRayPoint.point;
               // m_Player.SetDestination(l_HitRayPoint.point);
                Debug.Log(" object : "  + m_InteractibleObject.Count);
                //Debug.Log(m_Player.SetDestination(l_HitRayPoint.point));
            }
        }

        /*if(m_Player.velocity != Vector3.zero)
        {
            m_PlayerAnimator.SetBool("isWalking", true);
        }
        else if (m_Player.velocity == Vector3.zero)
        {
            m_PlayerAnimator.SetBool("isWalking", false);

        }*/
    }
}
