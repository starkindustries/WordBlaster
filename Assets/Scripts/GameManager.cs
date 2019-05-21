using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public void DidPressKey(char key)
    {
        Debug.Log(key);
        GetComponent<WordManager>().TypeLetter(letter: key);
    }
}
