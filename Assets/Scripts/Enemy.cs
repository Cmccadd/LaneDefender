using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float health = 3f; 
    public float hitPauseDuration = 1f;
    public Animator animator;

    private bool isHit = false; 
    private static readonly int HitHash = Animator.StringToHash("IsHit"); 

    void Update()
    {
        if (!isHit)
        {
            // Move the enemy forward if it is not currently hit
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an object tagged as "Bullet"
        if (collision.gameObject.CompareTag("Bullet") && !isHit)
        {
            TakeDamage(1f);
        }
    }

    private void TakeDamage(float damage)
    {
       
        health -= damage;

      
        StartCoroutine(HandleHit());

       
        if (health <= 0)
        {
            Die();
        }
    }

    private IEnumerator HandleHit()
    {
        if (!isHit)
        {
          
            SetHit(true);

          
            yield return new WaitForSeconds(hitPauseDuration);

           
            SetHit(false);
        }
    }

    private void SetHit(bool value)
    {
        isHit = value;
        if (animator != null)
        {
            animator.SetBool(HitHash, value); 
        }
    }

    private void Die()
    {
      
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        Destroy(gameObject, 1f); 
    }
}
