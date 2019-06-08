using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashcard
{
    private string front;
    private string back;

    public Flashcard(string front, string back)
    {
        this.front = front;
        this.back = back;
    }

    // Check Match Functions
    public bool DoesMatchFront(string front)
    {
        return this.front == front;
    }

    public bool DoesMatchBack(string back)
    {
        return this.back == back;
    }

    public bool Matches(Flashcard other)
    {
        return (this.front == other.front && this.back == other.back);
    }

    // Getter Functions
    public string GetFront()
    {
        return front;
    }

    public string GetBack()
    {
        return back;
    }
}
