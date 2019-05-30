using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Touchable
{
    void DidTap(Touch touch);
    void DidMoveTouch(Touch touch);
    void DidStationaryTouch(Touch touch);
}
