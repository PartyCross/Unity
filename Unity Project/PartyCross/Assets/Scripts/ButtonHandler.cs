using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class ButtonHandler : NetworkBehaviour
{
    [SerializeField] private string m_sceneName = "PartyCross";

    public void ShowTutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void CreateGame()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void IsSinglePlayer() {
        CurrentSettings.IsSinglePlayer();
    }

    public void IsMultiPlayer() {
        CurrentSettings.IsMultiPlayer();
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void OnlineLobby()
    {
        SceneManager.LoadScene(4);
    }

    public void StartHostGame()
    {
        NetworkManager.Singleton.StartHost();
        LoadScene();
        
    }

    public void StartClientGame()
    {
        NetworkManager.Singleton.StartClient();
        
    }

    public void LoadScene()
    {
       if(IsServer && !string.IsNullOrEmpty(m_sceneName))
        {
            var status = NetworkManager.SceneManager.LoadScene(m_sceneName, LoadSceneMode.Single);
        }
    }
}
