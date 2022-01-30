using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public static bool isWinning;

    public static int numberOfEnnemiesToWin;

    private float timeBeforeTheScene = 3;
    private bool hasWinState;

    [SerializeField]
    private GameObject tr2;

    [SerializeField]
    private string nameOfNextScene;
    // Start is called before the first frame update
    void Start()
    {
        numberOfEnnemiesToWin = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfEnnemiesToWin <= 0)
        {
            Win();
        }

        if (hasWinState)
        {
            timeBeforeTheScene -= Time.deltaTime;
        }

        if (timeBeforeTheScene <= 1)
        {
            tr2.SetActive(true);
        }
        if (timeBeforeTheScene <= 0)
        {
            SceneManager.LoadScene(nameOfNextScene);
        }
    }

    void Win()
    {
        isWinning = true;
        hasWinState = true;
      
    }
}
