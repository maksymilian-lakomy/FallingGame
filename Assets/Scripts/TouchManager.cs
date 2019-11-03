using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {
    public static Vector2 HorizontalTouch() {
        if (Input.touchCount <= 0 || Input.GetTouch(0).phase != TouchPhase.Began)
            return Vector2.zero;
        double screenWidth = Screen.width / 2d;
        Touch touch = Input.GetTouch(0);
        if (touch.position.x >= screenWidth)
            return Vector2.right;
        else
            return Vector2.left;
    }
}
