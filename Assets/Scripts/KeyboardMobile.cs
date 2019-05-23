using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMobile : MonoBehaviour
{
    public KeyboardButton q, w, e, r, t, y, u, i, o, p; // row 1
    public KeyboardButton a, s, d, f, g, h, j, k, l;    // row 2
    public KeyboardButton z, x, c, v, b, n, m;          // row 3
    public KeyboardButton spaceBar;

    private KeyboardButton[] keys;

    // private string keyChars = "qwertyuiopasdfghjklzxcvbnm ";
    private string keyChars = "ㅂㅈㄷㄱㅅㅛㅕㅑㅐㅔㅁㄴㅇㄹㅎㅗㅓㅏㅣㅋㅌㅊㅍㅠㅜㅡ ";

    // Start is called before the first frame update
    void Start()
    {
        keys = new KeyboardButton[] { q, w, e, r, t, y, u, i, o, p, a, s, d, f, g, h, j, k, l, z, x, c, v, b, n, m, spaceBar};
        for(int i=0; i < keys.Length; i++)
        {
            // Debug.Log("Key chars: " + keyChars[i].ToString());
            keys[i].Init(keyChars[i]);
        }
    }
}
