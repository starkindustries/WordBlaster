using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator: MonoBehaviour
{
    private static string[] wordList = { "test", "magic", "awesome", "game", "programmer" };

    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        return wordList[randomIndex];        
    }
}
