using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator: MonoBehaviour
{
    private static string[] wordList = { "word1", "word2", "word3", "word4", "word5" };

    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        return wordList[randomIndex];        
    }
}
