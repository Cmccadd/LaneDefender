using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    public Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D.velocity = transform.right * speed;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(rb2D);
    }

}
