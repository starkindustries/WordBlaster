using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;

    public GameObject wordPrefab;
    public float spawnRate;
    public Transform wordCanvas;

    private float nextSpawn;

    public WordDisplay SpawnWord()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-2.5f, 2.5f), 7f);

        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
        return wordObj.GetComponent<WordDisplay>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            float randX = Random.Range(minX, maxX);
            Vector2 location = new Vector2(randX, minY);
            Instantiate(wordPrefab, location, Quaternion.identity);
        }
    }
    */
}
