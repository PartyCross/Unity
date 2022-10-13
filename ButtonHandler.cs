using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

    public void ShowTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void JoinGame()
    {

    }

    public void PlayGame()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
