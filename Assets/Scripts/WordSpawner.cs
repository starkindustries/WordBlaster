using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    private string[] wordList = { "the", "quick", "brown", "fox", "jumped", "over", "lazy", "dog" };
    // private string[] wordList = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "a", "s", "d", "f", "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m"};

    public WordManager wordManager;
    public GameObject wordPrefab;
    public Transform wordCanvas;

    public Transform leftBoundary, rightBoundary;
    public float wordDelay = 1.5f;

    private float nextWordTime = 0f;    

    public WordDisplay SpawnWord()
    {
        Vector3 randomPosition = new Vector3(Random.Range(leftBoundary.position.x, rightBoundary.position.x), leftBoundary.position.y);
        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
        return wordObj.GetComponent<WordDisplay>();
    }

    public string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        return wordList[randomIndex];
    }

    private void Update()
    {
        if (Time.time >= nextWordTime)
        {
            wordManager.AddWord();
            nextWordTime = Time.time + wordDelay;
            wordDelay *= .99f;
        }
    }
}
