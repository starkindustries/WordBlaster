using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script is a component of the WordPrefab
// TextField is a sub-component of WordPrefab and is assigned in the GUI.
public class WordDisplay : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    public float speed;

    public void SetWord(string word)
    {
        tmpText.text = word;
    }

    public void RemoveLetter()
    {
        tmpText.text = tmpText.text.Remove(0, 1);
        tmpText.color = Color.red;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(0f, -speed * Time.deltaTime, 0f);
    }
}
