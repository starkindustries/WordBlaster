using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardButton : MonoBehaviour
{
    public Text uiText; 
    public char key;

    public void Start()
    {
        uiText.text = key.ToString();
        Debug.Log("KeyboardButton: " + key.ToString());
    }

    public void DidPressKey()
    {
        FindObjectOfType<GameManager>().DidPressKey(key);
    }
}
