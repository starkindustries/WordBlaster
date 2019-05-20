using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    public Text textField;
    public float speed;

    public void SetWord(string word)
    {
        textField.text = word;
    }

    public void RemoveLetter()
    {
        textField.text = textField.text.Remove(0, 1);
        textField.color = Color.red;
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
