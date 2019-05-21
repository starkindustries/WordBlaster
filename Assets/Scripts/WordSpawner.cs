using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public WordManager wordManager;
    public GameObject wordPrefab;
    public Transform wordCanvas;

    public float minX;
    public float maxX;
    public float minY;
    public float wordDelay = 1.5f;

    private float nextWordTime = 0f;    

    public WordDisplay SpawnWord()
    {
        Debug.Log("Spawn Word");
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), minY);
        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
        return wordObj.GetComponent<WordDisplay>();
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
