using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

    public void ShowTutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void CreateGame()
    {
        //pending server
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        //may not see use
        Application.Quit();
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
}
