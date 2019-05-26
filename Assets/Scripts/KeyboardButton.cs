using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardButton : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    private char key;

    public void Init(char newKey)
    {
        key = newKey;
        tmpText.text = key.ToString();
    }

    public void DidPressKey()
    {
        Debug.Log("DID PRESS: " + key.ToString());
        FindObjectOfType<WordManager>().TypeLetter(key);
        AudioManager.Instance.Play("Type");
    }
}
