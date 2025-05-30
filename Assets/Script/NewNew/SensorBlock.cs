using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorBlock : MonoBehaviour
{
    public Trap trapActivate; // 연결된 함정

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trapActivate?.ActivateTrap();
        }
    }
}
