using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour, Flashable
{
    public Flashcard card { get; set; }

    public float speed = 20f;
    public Rigidbody2D rb;
    public TextMeshProUGUI tmpText;
    public GameObject explosion;

    // public GameObject bulletParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        Destroy(this.gameObject, 2.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageComponent = collision.GetComponent<Damageable>();
        if (damageComponent == null )
        {
            Debug.LogWarning("Warning: damage component is null for " + collision.name);
            return; 
        }

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
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            damageComponent.Damage();
            FindObjectOfType<TestManager>().MatchMadeWith(card);
            return;
        }
        else
        {
            Debug.Log("CARDS DO NOT MATCH!!");
        }
    }

    public void SetFlashcard(Flashcard card)
    {
        this.card = card;
        tmpText.text = card.GetBack();
    }
}