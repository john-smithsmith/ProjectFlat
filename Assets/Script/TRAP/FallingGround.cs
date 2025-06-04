using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGround : MonoBehaviour
{
    public float fallDelay = 0.5f;     // �÷��̾� ��� �������� �ð� ����
    public float destroyDelay = 2f;    // �ٴ� ������ �� �ı��Ǳ���� �ð�

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
        rb.bodyType = RigidbodyType2D.Dynamic; // �߷�
        //Destroy(gameObject, destroyDelay); 
    }
}
