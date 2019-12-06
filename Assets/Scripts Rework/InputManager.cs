using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public static class InputManager {
    public static Vector2 GetHorizontalInput() {
        Vector2 horizontalInput = GetKeyboardHorizontalInput();
        if (horizontalInput == Vector2.zero)
            horizontalInput = GetTouchHorizontalInput();
        return horizontalInput;
    }
    
    private static Vector2 GetKeyboardHorizontalInput() {    
        return new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
    }
    
    private static Vector2 GetTouchHorizontalInput() {
        if (Input.touchCount <= 0 || Input.GetTouch(0).phase != TouchPhase.Began)
            return Vector2.zero;
        float screenCenterAxis = Screen.width / 2f;
        Touch touch = Input.GetTouch(0);
        if (touch.position.x >= screenCenterAxis)
            return Vector2.right;
        else
            return Vector2.left;
    }
}
