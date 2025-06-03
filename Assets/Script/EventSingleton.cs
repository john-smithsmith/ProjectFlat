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
            Destroy(gameObject); // 중복되면 제거
        }
        else
        {
            DontDestroyOnLoad(gameObject); // 유지
            instance = this;
        }
    }
}
