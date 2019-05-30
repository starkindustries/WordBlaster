using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public GameObject touchableObject;

    public Touchable touchable;
    private float[] timeTouchBegan;
    private bool[] touchDidMove;
    private float tapTimeThreshold = 0.2f;
    private float movementThreshold = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        timeTouchBegan = new float[10];
        touchDidMove = new bool[10];
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
            int fingerIndex = touch.fingerId;

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Finger #" + fingerIndex.ToString() + " entered!");
                timeTouchBegan[fingerIndex] = Time.time;
                touchDidMove[fingerIndex] = false;
            }
            if (touch.phase == TouchPhase.Stationary)
            {
                float tapTime = Time.time - timeTouchBegan[fingerIndex];
                if (tapTime > tapTimeThreshold)
                {
                    Debug.Log("Stationary Touch");
                    touchable.DidMoveTouch(touch);
                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.magnitude > movementThreshold)
                {
                    Debug.Log("Finger #" + fingerIndex.ToString() + " moved " + touch.deltaPosition.magnitude.ToString());
                    touchDidMove[fingerIndex] = true;
                    touchable.DidMoveTouch(touch);
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                float tapTime = Time.time - timeTouchBegan[fingerIndex];
                Debug.Log("Finger #" + fingerIndex.ToString() + " left. Tap time: " + tapTime.ToString());
                if (tapTime <= tapTimeThreshold && touchDidMove[fingerIndex] == false)
                {
                    Debug.Log("Finger #" + fingerIndex.ToString() + " TAP DETECTED at: " + touch.position.ToString());
                    touchable.DidTap(touch);
                }
            }
        }
    }    
}
