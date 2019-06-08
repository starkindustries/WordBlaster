using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour, Flashable, Damageable
{
    public Animator animator;
    public GameObject explosion;
    public Flashcard card { get; set; }
    public TextMeshProUGUI tmpText;
    public Transform location;

    // Start is called before the first frame update
    void Start()
    {
        tmpText.text = card.GetFront();
    }

    private void Update()
    {
        float step = 1.0f * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, location.position, step);
    }

    // Flashable Interface
    public void SetFlashcard(Flashcard card)
    {
        this.card = card;
        tmpText.text = card.GetFront();
    }

    public void Damage()
    {
        animator.SetTrigger("Die");
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);        
    }
}
