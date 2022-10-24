using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        KillOnTouch.OnPlayerDeath += EnableGameOverMenu;
        PlayerHealth.OnPlayerDeath += EnableGameOverMenu;
        
    }

    public void OnDisable()
    {
        KillOnTouch.OnPlayerDeath -= EnableGameOverMenu;
        PlayerHealth.OnPlayerDeath -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.GetComponent<AudioHandler>().KillPlayer();
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        gameOverMenu.GetComponent<AudioHandler>().RespawnPlayer();
        SceneManager.LoadScene(1);
    }
    
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
