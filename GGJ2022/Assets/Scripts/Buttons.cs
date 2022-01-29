using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private GameObject credits;

    [SerializeField]
    private GameObject sampleMenu;
    public void Play()
    {
        SceneManager.LoadScene("Carla");
    }

    public void Credits()
    {
        credits.SetActive(true);
        sampleMenu.SetActive(false);
    }

    public void Return()
    {
        credits.SetActive(false);
        sampleMenu.SetActive(true);
    }
}
