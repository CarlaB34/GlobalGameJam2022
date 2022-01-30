using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class PlayerControlledPointAndClick : MonoBehaviour
{
    #region Deplacement
    [SerializeField]
    private Camera m_cam;
    [SerializeField]
    private NavMeshAgent m_PlayerNav;
    [SerializeField]
    private GameObject m_TargetDestination;
    [SerializeField]
    private ParticleSystem m_EffectTargetDesti;
    #endregion

    #region objet interaction
    //objet qui quand on va interagir avec va laisser les differents niveau
    [SerializeField]
    private List<GameObject> m_InteractibleObject = new List<GameObject>();

    //objet qui quand on interagi avec, ils vont nous apporté des éléments scénaristique
    //permet aussi de favorisé et pratique le point and click
    [SerializeField]
    private List<GameObject> m_InteractibleObjectNULL = new List<GameObject>();
    #endregion

    #region voice
    //voie de la photo du papa (declanche niveau)
    [SerializeField]
    private FMODUnity.StudioEventEmitter m_Voice1;

    //voie de la fenetre (element narratif)
    [SerializeField]
    private FMODUnity.StudioEventEmitter m_Voice2;

    //voie du journal (declanche niveau)
    [SerializeField]
    private FMODUnity.StudioEventEmitter m_Voice3;

    //voie du livre (declanche niveau)
    [SerializeField]
    private FMODUnity.StudioEventEmitter m_Voice4;

    //voie du jutbox (element narratif)
    [SerializeField]
    private FMODUnity.StudioEventEmitter m_Voice5;
    #endregion

    [SerializeField]
    private bool m_IsVoice = false;

    private static int m_PassageDansScene = 0;

    //[SerializeField]
    //private Animator m_PlayerAnimator;

    private void Start()
    {
        Debug.Log("passage augmente pour int0 start: " + m_PassageDansScene);

        m_InteractibleObject[1].SetActive(false);
        Debug.Log("winstart condition dans PC : " + WinCondition.isWinning);
        m_InteractibleObject[2].SetActive(false);
    }

    private void Update()
    {
        ClickMove();
        // on  verifie a l'updta si ma voie est active
        VoiceActiveUtile();
        Debug.Log("passage augmente pour int0: " + m_PassageDansScene);
        Debug.Log("winupdate condition dans PC : " + WinCondition.isWinning);

        if (WinCondition.isWinning == true && m_PassageDansScene == 0)
        {
            m_InteractibleObject[1].SetActive(true);
                m_PassageDansScene += 1;
                WinCondition.isWinning = false;
                Debug.Log("interagible1");
            //if (m_PassageDansScene == 1)
            //{
            //    Debug.Log("interagible2");
            //    m_InteractibleObject[2].SetActive(true);
            //    //WinCondition.isWinning = false;
            //    Debug.Log("interagible2");
            //}

        }
        if (WinCondition.isWinning == true && m_PassageDansScene == 1)
        {
            Debug.Log("interagible2");
            m_InteractibleObject[2].SetActive(true);
            //WinCondition.isWinning = false;
            Debug.Log("interagible2");
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
        

    private void ClickMove()
    {
        //quand je click sur mon button gauche de la souris
        if (Input.GetMouseButtonDown(0))
        {
            //je tire un ray depuis la position de la souris dans la scene
            Ray l_Ray = m_cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit l_HitRayPoint;

            //nous fait avance
            if (Physics.Raycast(l_Ray, out l_HitRayPoint))
            {
                //on dit que la target correstpond a la position de ma souri
                m_TargetDestination.transform.position = l_HitRayPoint.point;
                m_EffectTargetDesti.Play();
                //j'avance avec le navmesh vers ce point
                m_PlayerNav.SetDestination(l_HitRayPoint.point);

                //si un element de ma liste contient un element que l'on touche de typ gameobject
                InteragibleObject(l_HitRayPoint);

                //si un element de ma liste contient un element que l'on touche de typ gameobjec
                InteragibleobjectNull(l_HitRayPoint);
            }
        }
    }

    private void InteragibleObject(RaycastHit p_RaycastHit)
    {
        //si un element de ma liste contient un element que l'on touche de typ gameobject
        if (m_InteractibleObject.Contains(p_RaycastHit.collider.gameObject))
        {
            //je vais switch entre mes differents element dans ma liste
            switch (p_RaycastHit.collider.gameObject.name)
            {
                //element 1
                case "PhotoPapa":
                    //m_Voice1.Play();
                    //m_IsVoice = true;
                    m_Voice1.Play();
                    m_Voice1.IsPlaying();
                    m_IsVoice = true;
                    break;

                //element 2
                case "JournalIntime":
                    m_Voice3.Play();
                    m_Voice3.IsPlaying();
                    m_IsVoice = true;
                    //Debug.Log("journal");
                    break;

                //element 3
                case "LivreDechirer":
                    //Debug.Log("livre");
                    m_Voice4.Play();
                    m_Voice4.IsPlaying();
                    m_IsVoice = true;
                    break;

            }
        }

    }

    private void InteragibleobjectNull(RaycastHit p_RaycastHit)
    {
        if (m_InteractibleObjectNULL.Contains(p_RaycastHit.collider.gameObject))
        {
            switch (p_RaycastHit.collider.gameObject.name)
            {
                //element 1
                case "Fenetre":
                    m_Voice2.Play();
                    m_Voice2.IsPlaying();
                    //m_IsVoice = true;
                    // Debug.Log("fenetre");

                    break;

                //element 2
                case "JutBox":
                    m_Voice5.Play();
                    m_Voice5.IsPlaying();
                    //m_IsVoice = true;
                    //Debug.Log("jutbox");
                    break;
            }
        }
    }

    private void VoiceActiveUtile()
    {

        //on  verifie a l'updta si ma voie est active
        if (m_IsVoice == true && m_Voice1.IsActive == true)
        {
            //on verifie ensuite si ma specifi voie est fause(terminer de se jouer) pour changer de scene
            if (m_Voice1.IsPlaying() == false)
            {
                //Debug.Log("papaS");
                SceneManager.LoadScene("Noam");
            }
        }
        if (m_IsVoice == true && m_Voice3.IsActive == true)
        {
            if (m_Voice3.IsPlaying() == false)
            {
                // Debug.Log("journalS");
                SceneManager.LoadScene("L2");
            }
        }
        if (m_IsVoice == true && m_Voice4.IsActive == true)
        {
            if (m_Voice4.IsPlaying() == false)
            {
                // Debug.Log("livreS");
                SceneManager.LoadScene("L3");
            }
        }
    }
}