using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    public WordSpawner wordSpawner;
    public Player player;

    private bool hasActiveWord;
    private Word activeWord;        

    public void AddWord()
    {        
        Word word = new Word(wordSpawner.GetRandomWord(), wordSpawner.SpawnWord());
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
                    player.SetTarget(activeWord.GetTransform());
                    break;
                }
            }
        }

        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
            player.SetTarget(null);
        }
    }    
}
