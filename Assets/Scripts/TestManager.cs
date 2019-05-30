using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] location;

    private GameObject[] activeEnemy;    

    // Start is called before the first frame update
    void Start()
    {        
        TestFlashcard();
                
        activeEnemy = new GameObject[4];
        for(int i=0; i < 4; i++)
        {
            Vector2 position = location[i].position + location[i].up * 10;
            activeEnemy[i] = Instantiate(enemy, position, Quaternion.identity);
            Flashable flashComponent = activeEnemy[i].GetComponent<Flashable>();
            flashComponent.card = new Flashcard("testfront", "testback");
        }
    }

    private void Update()
    {
        StartCoroutine(FlyEnemiesIntoView());                     
    }

    private IEnumerator FlyEnemiesIntoView()
    {
        float step = 1.0f * Time.deltaTime;
        for (int i = 0; i < 4; i++)
        {
            activeEnemy[i].transform.position = Vector3.Lerp(activeEnemy[i].transform.position, location[i].position, step);
            yield return new WaitForSeconds(0.2f);
        }
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
