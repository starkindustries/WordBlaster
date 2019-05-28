using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestFlashcard();
    }    

    public void TestFlashcard()
    {
        Debug.Log("Testing Flashcards");
        Flashcard card1 = new Flashcard("testFront", "testBack");
        Debug.Assert(card1.GetFront() == "testFront", "Flashcard error: Front of cards do NOT match!");        
        Debug.Assert(card1.GetBack() == "testBack", "Flashcard error: Back of cards do NOT match!");
        Debug.Assert(card1.DoesMatchFront("testFront"), "Flashcard error: Front of cards do NOT match!");
        Debug.Assert(card1.DoesMatchBack("testBack"), "Flashcard error: Back of cards do NOT match!");

        Flashcard card2 = new Flashcard("산", "mountain");
        Debug.Assert(card2.GetFront() == "산", "Flashcard error: Front of cards do NOT match!");        
        Debug.Assert(card2.GetBack() == "mountain", "Flashcard error: Back of cards do NOT match!");
        Debug.Assert(card2.DoesMatchFront("산"), "Flashcard error: Front of cards do NOT match!");
        Debug.Assert(card2.DoesMatchBack("mountain"), "Flashcard error: Back of cards do NOT match!");
    }
}
