using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator: MonoBehaviour
{
    private static string[] wordList = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "a", "s", "d", "f", "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m"};

    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        return wordList[randomIndex];        
    }
}
