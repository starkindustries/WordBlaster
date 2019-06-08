using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public GameObject touchableObject;

    public Touchable touchable;

    private bool mouseButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        touchable = touchableObject.GetComponent<Touchable>();
        if (touchable == null)
        {
            Debug.LogError("Touchable Object does NOT implement Touchable interface.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Touches
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                touchable.DidBeginTouch(touch.position);
            }
            if (touch.phase == TouchPhase.Stationary)
            {
                // Do nothing
            }
            if (touch.phase == TouchPhase.Moved)
            {
                touchable.DidMoveTouch(touch.position);
            }
            if (touch.phase == TouchPhase.Ended)
            {
                touchable.DidEndTouch(touch.position);
            }
        }

        // Mouse
        if (Input.GetButtonDown("Fire1"))
        {
            touchable.DidBeginTouch(Input.mousePosition);
            mouseButtonDown = true;
        }
        if (mouseButtonDown == true)
        {
            touchable.DidMoveTouch(Input.mousePosition);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            touchable.DidEndTouch(Input.mousePosition);
            mouseButtonDown = false;
        }        
    }        
}
