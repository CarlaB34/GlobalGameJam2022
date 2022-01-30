using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private GameObject credits;
    [SerializeField]
    private string nameOfNextScene;

    [SerializeField]
    private GameObject sampleMenu;
    [SerializeField]
    private GameObject tr;

    private bool isTransitionning;
    private float timeBeforeNextScene = 1;

    private void Update()
    {
        if(isTransitionning)
        {
            tr.SetActive(true);
            timeBeforeNextScene -= Time.deltaTime;
        }

        if(timeBeforeNextScene <= 0)
        {
            SceneManager.LoadScene(nameOfNextScene);
        }
    }
    public void Play()
    {
        isTransitionning = true;
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
