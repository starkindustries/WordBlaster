using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour, Flashable
{
    public Flashcard card { get; set; }

    public TextMeshProUGUI tmpText;

    // Start is called before the first frame update
    void Start()
    {
        tmpText.text = card.GetFront();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFlashcard(Flashcard card)
    {
        this.card = card;
        tmpText.text = card.GetFront();
    }
}
