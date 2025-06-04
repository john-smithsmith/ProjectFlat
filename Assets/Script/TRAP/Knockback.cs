using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    
    public float knockbackForce = 20f;
    public string targetTag = "Player";


    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag(targetTag))
        {
           
            Rigidbody2D targetRb = collision.collider.GetComponent<Rigidbody2D>();

           
            if (targetRb != null)
            {

                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;

                targetRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

                Debug.Log($"'{targetTag}'가 '{gameObject.name}'에 의해 튕겨남!");
            }
        }
    }
}