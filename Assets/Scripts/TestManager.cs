using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] location;
    public Transform spawnLocation;
    public GameObject ship;

    private GameObject[] activeEnemy;
    private int currentIndex = 0;
    private int[] indexList;
    private int[] shuffledIndexList;

    // Start is called before the first frame update
    void Start()
    {        
        TestFlashcard();

        SpawnNewEnemies();
        SetNextFlashcard();
    }

    private void SpawnNewEnemies()
    {
        // Get 20 random words. Spawn 4 at a time
        indexList = new int[4];
        for (int i = 0; i < 4; i++)
        {
            indexList[i] = UnityEngine.Random.Range(0, KoreanFlashcards.cards.Length);
        }

        activeEnemy = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            activeEnemy[i] = Instantiate(enemy, spawnLocation.position, Quaternion.identity);
            activeEnemy[i].GetComponent<Flashable>().SetFlashcard(KoreanFlashcards.cards[indexList[i]]);
            activeEnemy[i].GetComponent<Enemy>().location = location[i];
        }

        ShuffleList();        
    }

    public void SetNextFlashcard()
    {        
        if (currentIndex >= 4) {
            currentIndex = 0;
            SpawnNewEnemies();
        }
        int index = shuffledIndexList[currentIndex];
        SetShipFlashcard(index);
        currentIndex++;                
    }

    private void ShuffleList()
    {
        // https://stackoverflow.com/questions/273313/randomize-a-listt
        shuffledIndexList = new int[4];
        Array.Copy(indexList, shuffledIndexList, indexList.Length);
        int n = shuffledIndexList.Length;
        while(n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, 4);
            int value = shuffledIndexList[k];
            shuffledIndexList[k] = shuffledIndexList[n];
            shuffledIndexList[n] = value;
        }
    }

    private void SetShipFlashcard(int index)
    {
        ship.GetComponent<Flashable>().SetFlashcard(KoreanFlashcards.cards[index]);
    }
    /*
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
    }*/

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
