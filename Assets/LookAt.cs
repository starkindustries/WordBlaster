using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {        
        /*
        Word word = FindObjectOfType<WordManager>().GetActiveWord();
        if (word != null)
        {
            target = word.GetTransform();
            Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
            transform.right = direction;
        } 
        */
    }
}
