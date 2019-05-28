using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private float backgroundHeight;

    // Start is called before the first frame update
    void Start()
    {
        backgroundHeight = GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < backgroundHeight * -2)
        {
            RepositionBackground();
        }
        // Debug.Log("bg height: " + backgroundHeight + ", transform.position.y: " + transform.position.y);
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(0, backgroundHeight * 3f);
        transform.position = (Vector2)transform.position + groundOffset;
    }

}
