using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private static int numOfPlayers = 2;
    public static int GetNumOfPlayers () {return numOfPlayers;}

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void ThreePlayers ()
    {
        numOfPlayers = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void FourPlayers ()
    {
        numOfPlayers = 4;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
