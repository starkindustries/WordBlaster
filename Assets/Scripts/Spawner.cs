using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;

    public GameObject spawn;
    public float spawnRate;

    private float nextSpawn;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            float randX = Random.Range(minX, maxX);
            Vector2 location = new Vector2(randX, minY);
            Instantiate(spawn, location, Quaternion.identity);
        }
    }
}
