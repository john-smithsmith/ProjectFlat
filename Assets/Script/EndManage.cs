using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ENDManage : MonoBehaviour
{
    public GameObject endPanel; 

    void Start()
    {
        if (endPanel != null)
        {
            endPanel.SetActive(false);
        }
    }

    
    public void ShowEndPanel()
    {
        if (endPanel != null)
        {
            endPanel.SetActive(true);
            Time.timeScale = 0f; 
           
        }
    }

    

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("StartScene");
      
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }
}