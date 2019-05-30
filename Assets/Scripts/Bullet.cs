using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, Flashable
{
    public Flashcard card { get; set; }

    public float speed = 20f;
    public Rigidbody2D rb;    

    // public GameObject bulletParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        Destroy(this.gameObject, 3.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("BULLET HIT: " + collision.name);
        Flashable flashComponent = collision.GetComponent<Flashable>();
        if (flashComponent == null )
        {
            Debug.LogWarning("Warning: flashable component is null for " + collision.name);
            return;
        }

        if (flashComponent.card == null)
        {
            Debug.LogWarning("Warning: flashcard is null for " + collision.name);
            return;
        }
        
        if(flashComponent.card.GetFront() == card.GetFront())
        {
            Debug.Log("WE HAVE A MATCH!!");
        }
        else
        {
            Debug.Log("CARDS DO NOT MATCH!!");
        }
        // Instantiate(bulletParticles, transform.position, transform.rotation);
        // Destroy(this.gameObject);
    }
}