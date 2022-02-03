using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private bool m_GameIsPause = false;

    [SerializeField]
    private GameObject m_MenuPauseUI;

    private void Start()
    {
        m_MenuPauseUI.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(m_GameIsPause)
            {
                Resum();
            }
            else
            {
                Pauses();
            }
        }
    }


    public void Resum()
    {
        m_MenuPauseUI.SetActive(false);
        Time.timeScale = 1f;
        m_GameIsPause = false;
    }

    private void Pauses()
    {
        m_MenuPauseUI.SetActive(true);
        Time.timeScale = 0f;
        m_GameIsPause = true;
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
