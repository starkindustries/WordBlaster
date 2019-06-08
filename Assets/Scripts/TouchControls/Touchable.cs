using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Touchable
{
    void DidBeginTouch(Vector3 position);
    void DidMoveTouch(Vector3 position);
    void DidEndTouch(Vector3 position);
}
