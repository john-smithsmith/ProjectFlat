using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    
    public Transform target;

   
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTrigger");
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Player Tag");
            if (target != null)
            {
                other.transform.position = target.position;
            }
        }
    }
}

// 시작위치 지점으로 이동시키는 기능