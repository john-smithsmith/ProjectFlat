using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGround : MonoBehaviour
{
    public float fallDelay = 0.5f;     // 플레이어 닿고 떨어지는 시간 지연
    public float destroyDelay = 2f;    // 바닥 떨어진 뒤 파괴되기까지 시간

    private Rigidbody2D rb;
    private Vector3 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        startPos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
        }
    }

    void Fall()
    {
        rb.bodyType = RigidbodyType2D.Dynamic; // 중력
        //Destroy(gameObject, destroyDelay); 
    }
}
