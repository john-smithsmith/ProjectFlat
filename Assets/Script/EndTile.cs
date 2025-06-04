using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTrigger : MonoBehaviour
{
    public GameObject endingPanel; // UI �г� 

    private ENDManage endManager;
    void Start()
    {
        
        endManager = FindObjectOfType<ENDManage>();
        if (endManager == null)
        {
            
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("����");

            if (endManager != null)
            {
                endManager.ShowEndPanel();
            }
            else
            {
               
                // SceneManager.LoadScene("EndingScene");
            }
        }
    }
}
