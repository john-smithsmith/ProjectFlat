using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTrigger : MonoBehaviour
{
    public GameObject endingPanel; // UI 패널 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("엔딩");

            if (endingPanel != null)
            {
                endingPanel.SetActive(true);
                Time.timeScale = 0f; // 일시 정지 (선택)
            }
            else
            {
               
                // SceneManager.LoadScene("EndingScene");
            }
        }
    }
}
