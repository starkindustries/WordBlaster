using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    private bool hasActiveWord;
    private Word activeWord;

    public List<Word> words;    

    private void Start()
    {
        AddWord();
        AddWord();
        AddWord();
    }

    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord());
        words.Add(word);
        Debug.Log(word.word);
    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            // check if letter was next
            // remove it from word
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach(Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
}
