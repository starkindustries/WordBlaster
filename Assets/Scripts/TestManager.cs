using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public Transform location1;
    public GameObject enemy;
    private GameObject activeEnemy;    

    // Start is called before the first frame update
    void Start()
    {        
        TestFlashcard();
        // spawn enemy and move it to location 1
        Vector2 position = location1.position + location1.up * 10;
        activeEnemy = Instantiate(enemy, position, Quaternion.identity);                
    }

    private void Update()
    {        
        float step = 1.0f * Time.deltaTime;
        activeEnemy.transform.position = Vector3.Lerp(activeEnemy.transform.position, location1.position, step);
        // activeEnemy.transform.position = Vector2.MoveTowards(activeEnemy.transform.position, location1.position, step);                
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
