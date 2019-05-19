using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject counterText;
    public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increment()
    {
        Debug.Log("Increment!");
        counter++;
        counterText.GetComponentInChildren<Text>().text = "Count: " + counter.ToString();
    }

    public void DidPressKey(string key)
    {
        Debug.Log(key);
        counterText.GetComponentInChildren<Text>().text = key;
    }
}
