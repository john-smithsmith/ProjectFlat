using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform pointA; // ����
    public Transform pointB; // ������

    private Vector3 target;

    void Start()
    {
        target = pointB.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA.position) ? pointB.position : pointA.position;
            Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1; //����
        transform.localScale = scale;
    }
}
