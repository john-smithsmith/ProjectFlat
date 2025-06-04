using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float moveSpeed = 2f; 
    public float moveRange = 5f; 

    private float left;
    private float right;
    private bool movingRight = true; 

    void Start()
    {
        left = transform.position.x - (moveRange / 2f);
        right = transform.position.x + (moveRange / 2f);
    }

    void Update()
    {
       
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        
        if (movingRight && transform.position.x >= right)
        {
            movingRight = false; // 왼쪽으로 전환
            Flip(); // 방향 뒤집기
        }
        else if (!movingRight && transform.position.x <= left)
        {
            movingRight = true; 
            Flip(); 
        }
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}
