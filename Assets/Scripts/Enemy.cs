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

    private GameManager gameManager;

    public AudioClip hitSound;
    public AudioClip deathSound;

    private AudioSource audioSource;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (!isHit)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !isHit)
        {
            TakeDamage(1f);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.Lives();
            Destroy(gameObject);
        }
    }

    private void TakeDamage(float damage)
    {
        health -= damage;

        if (hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

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
        if (deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        gameManager.Score();

        Destroy(gameObject, 1f);
    }
}
