using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public Transform location1;
    public GameObject enemy;
    public Transform canvas;
    public GameObject ship;


    private Player player;
    private GameObject activeEnemy;
    private float shipSpeed = 10f;

    // records the time that a touch began. the index is the fingerId
    private float[] timeTouchBegan;
    private bool[] touchDidMove;
    private float tapTimeThreshold = 0.2f;
    private float movementThreshold = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
        TestFlashcard();
        // spawn enemy and move it to location 1
        Vector2 position = location1.position + location1.up * 10;
        activeEnemy = Instantiate(enemy, position, Quaternion.identity);
        
        timeTouchBegan = new float[10];
        touchDidMove = new bool[10];
        player = ship.GetComponent<Player>();
    }

    private void Update()
    {
        
        float step = 1.0f * Time.deltaTime;
        activeEnemy.transform.position = Vector3.Lerp(activeEnemy.transform.position, location1.position, step);
        // activeEnemy.transform.position = Vector2.MoveTowards(activeEnemy.transform.position, location1.position, step);
        
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
                    Debug.Log("STATIONARY!!!!");
                    MoveShip(touch.position);
                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.magnitude > movementThreshold)
                {
                    Debug.Log("Finger #" + fingerIndex.ToString() + " moved " + touch.deltaPosition.magnitude.ToString());
                    touchDidMove[fingerIndex] = true;

                    MoveShip(touch.position);
                }                
            }
            if (touch.phase == TouchPhase.Ended)
            {
                float tapTime = Time.time - timeTouchBegan[fingerIndex];
                Debug.Log("Finger #" + fingerIndex.ToString() + " left. Tap time: " + tapTime.ToString());
                if (tapTime <= tapTimeThreshold && touchDidMove[fingerIndex] == false)
                {
                    Debug.Log("Finger #" + fingerIndex.ToString() + " TAP DETECTED at: " + touch.position.ToString());
                    player.ShootBullet();
                }
            }         
        }
    }

    public void MoveShip(Vector2 touchPosition)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(touchPosition);
        position.z = 0;
        ship.transform.position = Vector3.Lerp(ship.transform.position, position, shipSpeed * Time.deltaTime);
    }

    public void TestFlashcard()
    {
        Debug.Log("Testing Flashcards");
        Flashcard card1 = new Flashcard("testFront", "testBack");
        Debug.Assert(card1.GetFront() == "testFront", "Flashcard error: Front of cards do NOT match!");        
        Debug.Assert(card1.GetBack() == "testBack", "Flashcard error: Back of cards do NOT match!");
        Debug.Assert(card1.DoesMatchFront("testFront"), "Flashcard error: Front of cards do NOT match!");
        Debug.Assert(card1.DoesMatchBack("testBack"), "Flashcard error: Back of cards do NOT match!");

        Flashcard card2 = new Flashcard("산", "mountain");
        Debug.Assert(card2.GetFront() == "산", "Flashcard error: Front of cards do NOT match!");        
        Debug.Assert(card2.GetBack() == "mountain", "Flashcard error: Back of cards do NOT match!");
        Debug.Assert(card2.DoesMatchFront("산"), "Flashcard error: Front of cards do NOT match!");
        Debug.Assert(card2.DoesMatchBack("mountain"), "Flashcard error: Back of cards do NOT match!");
    }
}
