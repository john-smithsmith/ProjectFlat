using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    
    public Transform target;

   
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            if (target != null)
            {
                other.transform.position = target.position;
            }
        }
    }
}

// ������ġ �������� �̵���Ű�� ���