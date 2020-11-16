using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool easyAI = false;
    public static bool hardAI = false;
    public static int option = 0;

    private static int numOfPlayers = 2;
    public static int GetNumOfPlayers() { return numOfPlayers; }

    public static bool GetHard() { return hardAI; }
    public static bool GetEasy() { return easyAI; }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void ThreePlayers()
    {
        numOfPlayers = 3;
        PlayGame();
    }
    public void FourPlayers()
    {
        numOfPlayers = 4;
        PlayGame();
    }

    public void computerAI()
    {
        numOfPlayers = 2;

        StartCoroutine("waitForOption");

    }

    public void EasyAI()
    {
        easyAI = true;
        PlayGame();
    }

    public void HardAI()
    {
        hardAI = true;
        PlayGame();
    }


    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    private IEnumerator waitForOption()
    {
        while (!Input.GetKeyDown(KeyCode.Alpha1) && !Input.GetKeyDown(KeyCode.Alpha2))
        {
            yield return null;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EasyAI();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HardAI();
        }

    }
}
