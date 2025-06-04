using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTrigger : MonoBehaviour
{
    public GameObject endingPanel; // UI �г� 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("����");

            if (endingPanel != null)
            {
                endingPanel.SetActive(true);
                Time.timeScale = 0f; // �Ͻ� ���� (����)
            }
            else
            {
               
                // SceneManager.LoadScene("EndingScene");
            }
        }
    }
}
