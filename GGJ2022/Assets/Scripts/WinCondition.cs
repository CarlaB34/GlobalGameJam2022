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
    private int originalNumberToKill;

    [SerializeField]
    private string nameOfNextScene;
    
    void Start()
    {
        numberOfEnnemiesToWin = originalNumberToKill;
        isWinning = false;
        Debug.Log("win bool start: " + isWinning);

    }

    // Update is called once per frame
    void Update()
    {
            Debug.Log("win bool update: " + isWinning);

        if (numberOfEnnemiesToWin <= 0)
        {
            Win();
            Debug.Log("tuer enemy");
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
