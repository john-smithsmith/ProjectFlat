using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemSingleton : MonoBehaviour
{
    private static EventSystemSingleton instance;

    void Awake()
    {
        if (FindObjectsOfType<EventSystem>().Length > 1)
        {
            Destroy(gameObject); // �ߺ��Ǹ� ����
        }
        else
        {
            DontDestroyOnLoad(gameObject); // ����
            instance = this;
        }
    }
}
