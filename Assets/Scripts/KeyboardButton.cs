using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardButton : MonoBehaviour
{
    public Text uiText; 
    public string key;

    public void Start()
    {
        uiText.text = key;
    }

    public void DidPressKey()
    {
        FindObjectOfType<GameManager>().DidPressKey(key);
    }
}
