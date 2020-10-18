using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenuManager : MonoBehaviour
{
    public static int howManyPlayers;

    public void TwoPlayers() 
    {
        howManyPlayers = 2;
        SceneManager.LoadScene("BoardScene");
    }
    public void ThreePlayers() 
    {
        howManyPlayers = 3;
        SceneManager.LoadScene("BoardScene");
    }
    public void FourPlayers() 
    {
        howManyPlayers = 4;
        SceneManager.LoadScene("BoardScene");
    }

    public void Quit()
    {
        if(EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
        }
    }
}
